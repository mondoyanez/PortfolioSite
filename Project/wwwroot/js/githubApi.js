$.ajax({
    type: "GET",
    dataType: "json",
    url: "/api/user",
    success: populateGitHubUserData,
    error: errorOnAjax
});

$.ajax({
    type: "GET",
    dataType: "json",
    url: "/api/repositories",
    success: populateGitHubRepoData,
    error: errorOnAjax
});

function populateGitHubRepoData(data) {
    for (let i = 0; i < data.length; ++i) {
        let repoTR = 
        `<tr>
            <td><button class="my-2 bg-blue-100 dark:bg-blue-900 text-sm font-serif font-bold text-blue-800 dark:text-blue-200 rounded-md p-1.5 hover:bg-yellow-200 dark:hover:bg-yellow-800" id="${data[i]["name"]}" value=${data[i]["fullName"]} type="button">${data[i]["fullName"]}</button></td>
        </tr>`;
        $("#repository-names").append((repoTR));
        $("#repository-names").show();
    }
}

function populateGitHubUserData(data) {
    $("#github-user-image").attr("src", data["avatarURL"]);
    $("#name-header").html(data["name"]);
    $("#github-username").html(data["userName"]);
    $("#github-email").html(data["email"]);
    $("#github-company").html(data["company"]);
    $("#github-location").html(data["location"]);
}

function errorOnAjax() {
    console.log("ERROR in ajax request");
}