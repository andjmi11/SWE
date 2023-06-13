window.endlessScroll = {
    init: function () {
        var content = document.getElementById('content'); //content
        var images = ['/other/cool-background.png', '/other/cool-background-reversed.png']; // Array of image URLs
        var currentIndex = 0; // Current index of the displayed image

        content.addEventListener('scroll', function () {
            // Check if the user has scrolled to the bottom
            if (content.scrollTop + content.clientHeight >= content.scrollHeight) {
                // Create a new content item div
                var newContentItem = document.createElement('div');
                newContentItem.classList.add('content-item');

                // Set the background image URL for the new content item
                newContentItem.style.backgroundImage = `url(${images[currentIndex]})`;

                // Increment the current index and reset if it exceeds the number of images
                currentIndex = (currentIndex + 1) % images.length;

                // Append the new content item to the content container
                content.appendChild(newContentItem);
            }
        });

        // Set the initial background image for the container
        content.style.backgroundImage = `url(${images[0]})`;
    }
};


//window.endlessScroll = {
//    init: function () {
//        var content = document.getElementById('content');
//        var images = ['/other/cool-background.png', '/other/cool-background-reversed.png']; // Array of image URLs
//        var currentIndex = 0; // Current index of the displayed image

//        content.addEventListener('scroll', function () {
//            // Check if the user has scrolled to the bottom
//            if (content.scrollTop + content.clientHeight >= content.scrollHeight) {
//                // Create a new content item div
//                var newContentItem = document.createElement('div');
//                newContentItem.classList.add('content-item');

//                // Set the background image URL for the new content item
//                newContentItem.style.backgroundImage = `url(${images[currentIndex]})`;

//                // Increment the current index and reset if it exceeds the number of images
//                currentIndex = (currentIndex + 1) % images.length;

//                // Append the new content item to the content container
//                content.appendChild(newContentItem);
//            }
//        });
//    }
//};




//// backgroundTrans.js
//window.backgroundTrans = {
//    initialize: function () {
//        window.addEventListener('scroll', function () {
//            if ((window.innerHeight + window.pageYOffset) >= document.body.offsetHeight) {
//                // Reached the end of the page
//                appendNextBackgroundImage();
//            }
//        });

//        var backgroundImages = [
//            '/other/cool-background.jpg',
//            '/other/cool-background-reversed.jpg'
//        ];

//        var currentBackgroundIndex = 0;

//        function appendNextBackgroundImage() {
//            var backgroundContainer = document.getElementById('backgroundContainer');
//            var nextBackgroundIndex = (currentBackgroundIndex + 1) % backgroundImages.length;
//            var nextBackgroundImageUrl = backgroundImages[nextBackgroundIndex];

//            var newDiv = document.createElement('div');
//            newDiv.className = 'zajednicki';
//            newDiv.style.backgroundImage = 'url(' + nextBackgroundImageUrl + ')';

//            backgroundContainer.appendChild(newDiv);

//            currentBackgroundIndex = nextBackgroundIndex;
//        }
//    }
//}
