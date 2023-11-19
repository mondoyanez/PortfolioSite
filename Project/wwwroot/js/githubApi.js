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

function displayBranchInfo(data) {
    console.log("Displaying branch information");
    console.log(data);
}

function displayCommitInfo(data) {
    console.log("Displaying commit information");
    console.log(data);
}

function displayRepoInfo(data) {
    console.log("Displaying repo information");
    console.log(data);

    $("#repository-info").append(`<h4 class="break-all w-1/2 text-2xl font-bold text-blue-800 dark:text-blue-200 pb-24"><a href="${data["htmlURL"]}" target="_blank" id="repository-header"">${data["fullName"]}</a></h4>`);
    $("#repository-info").append(`<p>Owner: ${data["owner"]}</p>`);
    $("#repository-info").append(`<p>Last Updated: ${data["lastUpdated"]} day(s) ago`);

    $("#github-repo-image").attr("src", data["ownerAvatarURL"]);
    $("#github-repo-image").show();

    $("#repository-header-name").show();

    $("#repository-container").show();
}

function populateGitHubRepoData(data) {
    for (let i = 0; i < data.length; ++i) {
        let repoTR = 
        `<tr>
            <td><button class="my-2 bg-blue-100 dark:bg-blue-900 text-sm font-serif font-bold text-blue-800 dark:text-blue-200 rounded-md p-1.5 hover:bg-yellow-200 dark:hover:bg-yellow-800" id="${data[i]["name"]}" value=${data[i]["fullName"]} type="button">${data[i]["fullName"]}</button></td>
        </tr>`;
        $("#repository-names").append((repoTR));
        $("#repository-names").show();
    }

    for (let i = 0; i < data.length; ++i) {
        document.addEventListener('click', function (event) {
            if (event.target.id === data[i]["name"]) {
                $("#commits-info").empty();
                $("#repository-info").empty();

                $("#commits-info").show();
                $("#repository-info").show();

                let params = `?owner=${data[i]["owner"]}&repo=${data[i]["name"]}`;
                let address = "/api/repository" + params;

                //https://stackoverflow.com/questions/31445242/ajax-request-response-order
                $.ajax({
                    type: "GET",
                    dataType: "json",
                    url: address,
                    success: displayRepoInfo,
                    error: errorOnAjax,
                    async: false
                });

                address = "/api/branches" + params;

                $.ajax({
                    type: "GET",
                    dataType: "json",
                    url: address,
                    success: displayBranchInfo,
                    error: errorOnAjax
                });

                address = "/api/commits" + params;

                $.ajax({
                    type: "GET",
                    dataType: "json",
                    url: address,
                    success: displayCommitInfo,
                    error: errorOnAjax
                });
            }
        })
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