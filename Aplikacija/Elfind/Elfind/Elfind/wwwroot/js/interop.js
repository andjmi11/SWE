
window.getPictureCoordinates = function (elementId) {
    var element = document.getElementById(elementId);

    if (element) {
        var rect = element.getBoundingClientRect();
        var left = rect.left;
        var top = rect.top;

        return { "left": left, "top": top };
    }

    return null;
};

