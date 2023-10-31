console.log("hello world from GitHub Api javascript file");

$.ajax({
    type: "GET",
    dataType: "json",
    url: "/api/user",
    success: populateGitHubUserData,
    error: errorOnAjax
});

function populateGitHubUserData(data) {
    $("#github-user-image").attr("src", data["avatarURL"]);
    $("#name-header").html(data["name"]);
    $("#github-username").html(data["userName"]);
    $("#github-email").html(data["email"]);
    $("#github-company").html(data["company"]);
    $("#github-location").html(data["location"]);
    console.log(data);
}

function errorOnAjax() {
    console.log("ERROR in ajax request");
}