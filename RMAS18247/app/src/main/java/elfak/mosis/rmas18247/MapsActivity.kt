package elfak.mosis.rmas18247

import android.Manifest
import android.app.AlertDialog
import android.content.SharedPreferences
import android.content.pm.PackageManager
import android.location.Location
import android.os.Bundle
import android.view.View
import android.widget.Button
import androidx.appcompat.app.AppCompatActivity
import androidx.core.app.ActivityCompat
import com.google.android.gms.location.FusedLocationProviderClient
import com.google.android.gms.location.LocationServices
import com.google.android.gms.maps.CameraUpdateFactory
import androidx.fragment.app.Fragment;
import com.google.android.gms.maps.GoogleMap
import com.google.android.gms.maps.OnMapReadyCallback
import com.google.android.gms.maps.SupportMapFragment
import com.google.android.gms.maps.model.BitmapDescriptorFactory
import com.google.android.gms.maps.model.LatLng
import com.google.android.gms.maps.model.Marker
import com.google.android.gms.maps.model.MarkerOptions
import com.google.gson.Gson
import com.google.gson.reflect.TypeToken
import elfak.mosis.rmas18247.databinding.ActivityMapsBinding

class MapsActivity : AppCompatActivity(), OnMapReadyCallback, GoogleMap.OnMarkerClickListener,
    GoogleMap.OnMapClickListener {

    private lateinit var mMap: GoogleMap
    private lateinit var binding: ActivityMapsBinding

    private lateinit var lastLocation: Location
    private lateinit var fusedLocationClient: FusedLocationProviderClient

    private lateinit var sharedPreferences: SharedPreferences
    private lateinit var gson: Gson
    private lateinit var markerList: MutableList<LatLng>

    companion object {
        private const val LOCATION_REQUEST_CODE = 1
        private const val PREFERENCE_NAME = "MapPins"
        private const val PREFERENCE_KEY_MARKERS = "markers"
    }

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)

        binding = ActivityMapsBinding.inflate(layoutInflater)
        setContentView(binding.root)

        val mapFragment = supportFragmentManager
            .findFragmentById(R.id.map) as SupportMapFragment
        mapFragment.getMapAsync(this)

        fusedLocationClient = LocationServices.getFusedLocationProviderClient(this)

        sharedPreferences = getSharedPreferences(PREFERENCE_NAME, MODE_PRIVATE)
        gson = Gson()
        markerList = mutableListOf()
    }

    override fun onMapReady(googleMap: GoogleMap) {
        mMap = googleMap

        mMap.uiSettings.isZoomControlsEnabled = true
        mMap.setOnMarkerClickListener(this)
        mMap.setOnMapClickListener(this)

        loadSavedMarkers() // Load saved markers when the map is ready
        setUpMap()
    }

    private fun setUpMap() {
        // Check location permission
        if (ActivityCompat.checkSelfPermission(
                this,
                Manifest.permission.ACCESS_FINE_LOCATION
            ) != PackageManager.PERMISSION_GRANTED
        ) {
            ActivityCompat.requestPermissions(
                this,
                arrayOf(Manifest.permission.ACCESS_FINE_LOCATION),
                LOCATION_REQUEST_CODE
            )
            return
        }

        mMap.isMyLocationEnabled = true
        fusedLocationClient.lastLocation.addOnSuccessListener(this) { location ->
            if (location != null) {
                lastLocation = location
                val currentLatLong = LatLng(location.latitude, location.longitude)

                placeMarkerOnMap(currentLatLong)
                mMap.animateCamera(
                    CameraUpdateFactory.newLatLngZoom(
                        currentLatLong,
                        12f
                    )
                )
            }
        }
    }

    private fun placeMarkerOnMap(currentLatLong: LatLng) {
        val markerOptions = MarkerOptions().position(currentLatLong)
            .icon(BitmapDescriptorFactory.defaultMarker(BitmapDescriptorFactory.HUE_ROSE))
        //mMap.addMarker(markerOptions)

        if (::lastLocation.isInitialized && currentLatLong != getCurrentLocationLatLng()) {
            mMap.addMarker(markerOptions)
            markerList.add(currentLatLong) // Add the marker to the list
            //saveMarkers() // Save the updated list of markers
        }
        else{
            mMap.addMarker(markerOptions)
        }
        saveMarkers()
    }

    override fun onMarkerClick(marker: Marker) : Boolean {

        val dialogView: View = layoutInflater.inflate(R.layout.dialog_pin, null)

        val dialogBuilder = AlertDialog.Builder(this)
            .setView(dialogView)

        val dialog = dialogBuilder.create()
        dialog.show()

        val btnPinDel = dialogView.findViewById<Button>(R.id.btnPinDelete)
        val btnPinInfo = dialogView.findViewById<Button>(R.id.btnPinInfo)

        btnPinDel.setOnClickListener {

            marker.remove()
            markerList.remove(marker.position)
            saveMarkers()

            dialog.dismiss()

            mMap.clear()
            placeMarkerOnMap(LatLng(lastLocation.latitude, lastLocation.longitude))
            loadSavedMarkers()
        }

        btnPinInfo.setOnClickListener {
            dialog.dismiss()
        }

        return true
    }

    private fun getCurrentLocationLatLng(): LatLng {
        return if (::lastLocation.isInitialized) {
            LatLng(lastLocation.latitude, lastLocation.longitude)
        } else {
            LatLng(0.0, 0.0) // Default location if lastLocation is not initialized
        }
    }
    override fun onMapClick(latLng: LatLng) {
        val dialogView: View = layoutInflater.inflate(R.layout.dialog_touch, null)

        val dialogBuilder = AlertDialog.Builder(this)
            .setView(dialogView)

        val dialog = dialogBuilder.create()
        dialog.show()

        val btnPinLoc = dialogView.findViewById<Button>(R.id.btnPinLocation)

        btnPinLoc.setOnClickListener {
            placeMarkerOnMap(latLng) //type 1
            dialog.dismiss()
        }
    }

    private fun saveMarkers() {
        val markerJson = gson.toJson(markerList)
        val editor = sharedPreferences.edit()
        editor.putString(PREFERENCE_KEY_MARKERS, markerJson)
        editor.apply()
    }

    private fun loadSavedMarkers() {
        val markerJson = sharedPreferences.getString(PREFERENCE_KEY_MARKERS, null)
        if (markerJson != null) {
            val markerType = object : TypeToken<List<LatLng>>() {}.type
            val savedMarkers = gson.fromJson<List<LatLng>>(markerJson, markerType)
            markerList.addAll(savedMarkers)

            for (markerLocation in savedMarkers) {
                placeMarkerOnMap(markerLocation)
            }
        }
    }

    private fun deleteAllMarkers() {
        markerList.clear() // Clear the marker list

        // Remove all markers from the map
        mMap.clear()

        // Clear the saved markers from SharedPreferences
        val editor = sharedPreferences.edit()
        editor.remove(PREFERENCE_KEY_MARKERS)
        editor.apply()
    }

}