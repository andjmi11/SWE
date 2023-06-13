window.getElementByID = function (id) {
    return document.getElementById(id);
}

window.getClickTarget = function (event) {
    return event.target;
};

window.isDescendantOfElement = function (child, parent) {
    return parent.contains(child);
};

window.isConnected = function () {
    return true; // Replace with your own logic to determine the connected state
};
