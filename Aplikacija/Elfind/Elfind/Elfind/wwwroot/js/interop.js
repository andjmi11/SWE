//namespace Elfind.wwwroot.js
//{
//    public class interop
//    {
//        // JavaScript interop method
//        window.getPictureCoordinates = (elementId) => {
//            const element = document.getElementById(elementId);
//            const rect = element.getBoundingClientRect();
//            return rect;
//        };

//    }
//}

//function getDivCoordinates(divId) {
//    var divElement = document.getElementById(divId);
//    var rect = divElement.getBoundingClientRect();

//    return {
//        left: rect.left,
//        top: rect.top
//    };
//}

window.getPictureCoordinates = function (elementId) {
    var element = document.getElementById(elementId);

    if (element) {
        var rect = element.getBoundingClientRect();
        var left = rect.left;
        var top = rect.top;

        // Return the coordinates as an object
        return { "left": left, "top": top };
    }

    return null;
};
