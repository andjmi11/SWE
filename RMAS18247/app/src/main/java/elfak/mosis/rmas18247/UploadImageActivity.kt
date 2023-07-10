package elfak.mosis.rmas18247

import android.app.Activity
import android.content.ActivityNotFoundException
import android.content.Intent
import android.graphics.Bitmap
import android.net.Uri
import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.provider.MediaStore
import android.provider.Settings
import android.widget.Toast
import androidx.appcompat.app.AlertDialog
import coil.load
import coil.transform.CircleCropTransformation
import com.karumi.dexter.Dexter
import com.karumi.dexter.MultiplePermissionsReport
import com.karumi.dexter.PermissionToken
import com.karumi.dexter.listener.PermissionDeniedResponse
import com.karumi.dexter.listener.PermissionGrantedResponse
import com.karumi.dexter.listener.PermissionRequest
import com.karumi.dexter.listener.multi.MultiplePermissionsListener
import com.karumi.dexter.listener.single.PermissionListener
import android.Manifest
import android.os.Environment
import com.google.firebase.storage.FirebaseStorage
import com.google.firebase.storage.StorageReference
import elfak.mosis.rmas18247.databinding.ActivityUploadImageBinding
import java.io.File
import java.io.FileOutputStream
import java.io.IOException
import java.util.*

class UploadImageActivity : AppCompatActivity() {

    private lateinit var binding: ActivityUploadImageBinding
    private val CAMERA_REQUEST_CODE = 1
    private  var GALLERY_REQUEST_CODE = 2

    private var tempImageFile: File? = null


    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        binding = ActivityUploadImageBinding.inflate(layoutInflater)
        setContentView(binding.root)

        binding.btnCamera.setOnClickListener{
            cameraCheckPermission()
        }

        binding.btnGallery.setOnClickListener{
            galleryCheckPermission()
        }
    }

    private fun galleryCheckPermission() {
        val permissionListener = object : PermissionListener {
            override fun onPermissionGranted(response: PermissionGrantedResponse?) {
                gallery()
            }

            override fun onPermissionDenied(response: PermissionDeniedResponse?) {
                Toast.makeText(
                    this@UploadImageActivity,
                    "Odbili ste dozvolu da izaberete sliku",
                    Toast.LENGTH_SHORT
                ).show()
                showRotationalDialogForPermission()
            }

            override fun onPermissionRationaleShouldBeShown(
                permission: PermissionRequest?,
                token: PermissionToken?
            ) {
                showRotationalDialogForPermission()
            }
        }

        Dexter.withContext(this)
            .withPermission(Manifest.permission.READ_EXTERNAL_STORAGE)
            .withListener(permissionListener)
            .onSameThread()
            .check()
    }


    private fun gallery(){
        val intent = Intent(Intent.ACTION_PICK)
        intent.type = "image/*"
        startActivityForResult(intent, GALLERY_REQUEST_CODE)

    }
    private fun cameraCheckPermission(){
        Dexter.withContext(this)
            .withPermissions(android.Manifest.permission.READ_EXTERNAL_STORAGE,
            android.Manifest.permission.CAMERA).withListener(
                object: MultiplePermissionsListener{
                    override fun onPermissionsChecked(report: MultiplePermissionsReport?) {
                        report?.let {
                            if(report.areAllPermissionsGranted()){
                                camera()
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

    private fun camera(){
        val intent = Intent(MediaStore.ACTION_IMAGE_CAPTURE)
        startActivityForResult(intent, CAMERA_REQUEST_CODE)
    }

    override fun onActivityResult(requestCode: Int, resultCode: Int, data: Intent?) {
        super.onActivityResult(requestCode, resultCode, data)

        if(resultCode == Activity.RESULT_OK){
            when(requestCode){
                CAMERA_REQUEST_CODE -> {

                    val bitmap = data?.extras?.get("data") as Bitmap
                    binding.imageView.load(bitmap){
                        crossfade(true)
                        crossfade(1000)
                        transformations(CircleCropTransformation())
                    }

                    tempImageFile = saveBitmapToFile(bitmap)
                }

                GALLERY_REQUEST_CODE -> {
                    binding.imageView.load(data?.data){
                        crossfade(true)
                        crossfade(1000)
                        transformations(CircleCropTransformation())
                    }

                }
            }
        }
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

    private fun saveBitmapToFile(bitmap: Bitmap): File? {
        return try {
            val tempDir = getExternalFilesDir(Environment.DIRECTORY_PICTURES)
            val tempFile = File.createTempFile("tempImage", ".jpg", tempDir)
            val outputStream = FileOutputStream(tempFile)
            bitmap.compress(Bitmap.CompressFormat.JPEG, 100, outputStream)
            outputStream.flush()
            outputStream.close()
            tempFile
        } catch (e: IOException) {
            e.printStackTrace()
            null
        }
    }







}

