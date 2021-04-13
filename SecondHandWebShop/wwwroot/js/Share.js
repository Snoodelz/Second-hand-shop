const facebookBtn = document.getElementById("facebook");
const twitterBtn = document.getElementById("twitter");
//const instagramBtn = document.querySelector(".btn-instagram");


function init() {
    let postUrl = encodeURI(document.location.href);
    let postTitle = encodeURI("Hi everyone, please check this out.");
    facebookBtn.setAttribute("href", `https://www.facebook.com/sharer.php?u=${postUrl}`);
    twitterBtn.setAttribute("href", `https://twitter.com/share?url=${postUrl}&text=${postTitle}`);
}
init();