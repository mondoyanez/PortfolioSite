console.log("hello world from GitHub Api javascript file");

$.ajax({
    type: "GET",
    dataType: "json",
    url: "/api/user",
    success: populateGitHubUserData,
    error: errorOnAjax
});

function populateGitHubUserData(data) {
    /*
    $("#github-user-image").attr("src", data["avatarURL"]);
    $("#github-user-info").append(`<h1 id="name-header"> ${data["name"]} </h1>`);
    $("#github-user-info").append(`<p id="github-account-info"> ${data["userName"]}`);
    $("#github-user-info").append(`<p id="github-account-info"> ${data["email"]}`);
    $("#github-user-info").append(`<p id="github-account-info"> ${data["company"]}`);
    $("#github-user-info").append(`<p id="github-account-info"> ${data["location"]}`);
    */
   console.log(data);
}

function errorOnAjax() {
    console.log("ERROR in ajax request");
}