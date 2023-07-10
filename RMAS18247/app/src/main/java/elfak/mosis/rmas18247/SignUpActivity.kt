package elfak.mosis.rmas18247

import android.content.Intent
import android.Manifest
import android.app.Activity
import android.content.ActivityNotFoundException
import android.content.pm.PackageManager
import android.graphics.Bitmap
import android.graphics.BitmapFactory
import android.net.Uri
import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.os.Environment
import android.provider.MediaStore
import android.provider.Settings
import android.view.View
import android.widget.Toast
import androidx.activity.result.ActivityResult
import androidx.activity.result.ActivityResultLauncher
import androidx.activity.result.contract.ActivityResultContracts
import androidx.appcompat.app.AlertDialog
import androidx.core.app.ActivityCompat
import androidx.core.content.ContextCompat
import androidx.core.content.FileProvider
import coil.load
import coil.transform.CircleCropTransformation
import com.google.firebase.auth.FirebaseAuth
import com.google.firebase.database.DatabaseReference
import com.google.firebase.database.FirebaseDatabase
import com.google.firebase.storage.FirebaseStorage
import com.google.firebase.storage.StorageReference
import com.karumi.dexter.Dexter
import com.karumi.dexter.MultiplePermissionsReport
import com.karumi.dexter.PermissionToken
import com.karumi.dexter.listener.PermissionRequest
import com.karumi.dexter.listener.multi.MultiplePermissionsListener
import elfak.mosis.rmas18247.databinding.ActivitySignUpBinding
import java.io.*
import java.text.SimpleDateFormat
import java.util.*

class SignUpActivity : AppCompatActivity() {

    private lateinit var binding : ActivitySignUpBinding
    private lateinit var firebaseAuth: FirebaseAuth
    private lateinit var databaseRef : DatabaseReference
    var profileImg:String? = ""
    private val CAMERA_REQUEST_CODE = 1



    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        binding = ActivitySignUpBinding.inflate(layoutInflater)
        setContentView(binding.root)

        firebaseAuth = FirebaseAuth.getInstance()


        /*  binding.uploadImageButton.setOnClickListener{
              val uploadImageIntent = Intent(this, UploadImageActivity::class.java)

          }*/

        val activityResultLauncher = registerForActivityResult<Intent, ActivityResult>(
            ActivityResultContracts.StartActivityForResult()
        ){result: ActivityResult ->
            if(result.resultCode == RESULT_OK){

                val uri = result.data!!.data
                try {
                    val inputStream = contentResolver.openInputStream(uri!!)
                    val myBitmap = BitmapFactory.decodeStream(inputStream)
                    val stream = ByteArrayOutputStream()
                    myBitmap.compress(
                        Bitmap.CompressFormat.PNG, 100, stream
                    )
                    val bytes = stream.toByteArray()
                    profileImg = android.util.Base64.encode(bytes, android.util.Base64.DEFAULT).toString()
                    binding.profileImg.setImageBitmap(myBitmap)
                    inputStream!!.close()
                    Toast.makeText(this, "Slika je odabrana!", Toast.LENGTH_SHORT).show()

                }catch (exc: java.lang.Exception){
                    Toast.makeText(this, exc.message.toString(), Toast.LENGTH_SHORT).show()
                }
            }
        }

        binding.uploadPictureButton.setOnClickListener{
            uploadPicture(this@SignUpActivity, activityResultLauncher)
        }
        binding.signupButton.setOnClickListener {

                val email = binding.signupEmail.text.toString()
                val password = binding.signupPassword.text.toString()
                val confirmPassword = binding.signupConfirm.text.toString()
                val firstName = binding.signupFirstName.text.toString()
                val lastName = binding.signupSecondName.text.toString()
                val phone = binding.signupPhone.text.toString()

                databaseRef = FirebaseDatabase.getInstance().getReference("users")
                val user = User(email, firstName, lastName, phone,profileImg)
                val databaseReference = FirebaseDatabase.getInstance().reference
                val id = databaseReference.push().key

                databaseRef.child(id.toString()).setValue(user).addOnSuccessListener {
                    binding.signupEmail.text?.clear()
                    binding.signupPassword.text?.clear()
                    binding.signupConfirm.text?.clear()
                    binding.signupFirstName.text?.clear()
                    binding.signupSecondName.text?.clear()
                    binding.signupPhone.text?.clear()
                    profileImg = ""
                    Toast.makeText(this, "Podaci su sačuvani", Toast.LENGTH_SHORT).show()

                }.addOnFailureListener{
                    Toast.makeText(this, "Podaci nisu sačuvani", Toast.LENGTH_SHORT).show()
                }


                if (email.isNotEmpty() && password.isNotEmpty() && confirmPassword.isNotEmpty()
                    && firstName.isNotEmpty() && lastName.isNotEmpty() && phone.isNotEmpty()
                ) {

                    if (password == confirmPassword) {
                        firebaseAuth.createUserWithEmailAndPassword(email, password)
                            .addOnCompleteListener { task ->
                                if (task.isSuccessful) {
                                    val user = firebaseAuth.currentUser
                                    val userId = user?.uid

                                    if (userId != null) {
                                        val userRef = databaseRef.child("users").child(userId)
                                        userRef.child("email").setValue(email)
                                        userRef.child("firstName").setValue(firstName)
                                        userRef.child("lastName").setValue(lastName)
                                        userRef.child("phone").setValue(phone)

                                        Toast.makeText(
                                            this,
                                            "Uspešno ste se prijavili!",
                                            Toast.LENGTH_SHORT
                                        ).show()
                                        val intent = Intent(this, LoginActivity::class.java)
                                        startActivity(intent)
                                    }
                                } else {
                                    Toast.makeText(
                                        this,
                                        task.exception?.message,
                                        Toast.LENGTH_SHORT
                                    ).show()
                                }
                            }
                    } else {
                        Toast.makeText(this, "Lozinke se ne poklapaju!", Toast.LENGTH_SHORT).show()
                    }

                } else {
                    Toast.makeText(this, "Polja ne smeju biti prazna!", Toast.LENGTH_SHORT).show()
                }

        }

        binding.loginRedirectText.setOnClickListener{
            val loginIntent = Intent(this, LoginActivity::class.java)
            startActivity(loginIntent)


        }



    }

    private fun uploadPicture(signUpActivity: SignUpActivity, launcher: ActivityResultLauncher<Intent>){

        val builder = AlertDialog.Builder(signUpActivity)
        builder.setMessage("Odaberite način dodavanja fotografije:")

        builder.setPositiveButton("Galerija"){ dialogInterface, _ ->

            var myfileintent =Intent(Intent.ACTION_GET_CONTENT)
            myfileintent.setType("image/*")
            launcher.launch(myfileintent)

        }

        builder.setNegativeButton("Kamera" ){dialogInterface, _ ->
            cameraCheckPermission(launcher)

        }

        builder.show()

    }

    private fun cameraCheckPermission(launcher: ActivityResultLauncher<Intent>){
        Dexter.withContext(this)
            .withPermissions(android.Manifest.permission.READ_EXTERNAL_STORAGE,
                android.Manifest.permission.CAMERA).withListener(
                object: MultiplePermissionsListener {
                    override fun onPermissionsChecked(report: MultiplePermissionsReport?) {
                        report?.let {
                            if(report.areAllPermissionsGranted()){
                                camera(launcher)
                            }
                        }
                    }

                    override fun onPermissionRationaleShouldBeShown(
                        p0: MutableList<PermissionRequest>?,
                        p1: PermissionToken?
                    ) {
                        showRotationalDialogForPermission()
                    }
                }
            ).onSameThread().check()
    }

    private fun camera(launcher: ActivityResultLauncher<Intent>){
        val intent = Intent(MediaStore.ACTION_IMAGE_CAPTURE)
        startActivityForResult(intent, CAMERA_REQUEST_CODE)
    }

    override fun onActivityResult(requestCode: Int, resultCode: Int, data: Intent?) {
        super.onActivityResult(requestCode, resultCode, data)

        if(resultCode == Activity.RESULT_OK) {
            when (requestCode) {
                CAMERA_REQUEST_CODE -> {
                    val bitmap = data?.extras?.get("data") as Bitmap
                    val uri = getImageUri(bitmap)
                    binding.profileImg.load(uri) {
                        crossfade(true)
                        crossfade(1000)
                    }
                    val inputStream = contentResolver.openInputStream(uri!!)
                    val myBitmap = BitmapFactory.decodeStream(inputStream)
                    val stream = ByteArrayOutputStream()
                    myBitmap.compress(
                        Bitmap.CompressFormat.PNG, 100, stream
                    )
                    val bytes = stream.toByteArray()
                    profileImg = android.util.Base64.encode(bytes, android.util.Base64.DEFAULT).toString()
                    binding.profileImg.setImageBitmap(myBitmap)
                    inputStream!!.close()
                    Toast.makeText(this, "Slika je odabrana!", Toast.LENGTH_SHORT).show()

                }
            }
        }
    }

    private fun getImageUri(bitmap: Bitmap): Uri {
        val bytes = ByteArrayOutputStream()
        bitmap.compress(Bitmap.CompressFormat.JPEG, 100, bytes)
        val path = MediaStore.Images.Media.insertImage(contentResolver, bitmap, "Title", null)
        return Uri.parse(path)
    }

    private fun showRotationalDialogForPermission(){
        AlertDialog.Builder(this)
            .setMessage("Izgleda ste isključili dozvole potrebne za ovu funckiju. Možete ih uključiti u podešavanjima aplikacije.")
            .setPositiveButton("Idi u podešavanja:"){_,_ ->
                try {
                    val intent = Intent(Settings.ACTION_APPLICATION_DETAILS_SETTINGS)
                    val uri = Uri.fromParts("package", packageName, null)
                    intent.data = uri
                    startActivity(intent)
                }catch(exc: ActivityNotFoundException){
                    exc.printStackTrace()
                }
            }
            .setNegativeButton("Poništi"){dialog,_ ->
                dialog.dismiss()
            }.show()

    }

}