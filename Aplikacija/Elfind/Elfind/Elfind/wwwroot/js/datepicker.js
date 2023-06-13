//function initializeDatePicker(element) {
//    $(element).datepicker({
//        // Specify the desired options for the date picker
//        // For example:
//        dateFormat: "dd-mm-yy",
//        // ... other options
//    });
//}

//function getDatePickerValue(element) {
//    return $(element).datepicker("getDate").toISOString().split("T")[0];
//}

function showCalendar() {
    document.getElementById("calendarContainer").style.display = "block";
}

function hideCalendar() {
    document.getElementById("calendarContainer").style.display = "none";
}

//function dateSelected(day) {
//    DotNet.invokeMethodAsync("YourProjectNamespace", "DateSelected", day);
//    //hideCalendar();
//}
 

//function dateSelected(selectedDate) {
//    DotNet.invokeMethodAsync("YourProjectNamespace", "DateSelected", selectedDate);
//}

//function loadCalendarScript() {
//    var script = document.createElement('script');
//    script.src = 'path/to/datepicker.js'; // Replace with the actual path to your datepicker.js file
//    script.onload = function () {
//        showCalendar(); // Call the showCalendar function once the script is loaded
//    };
//    document.body.appendChild(script);
//}
