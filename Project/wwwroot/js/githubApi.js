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
    $("#repository-info").append(`<p class="p-1.5">Branches:</p>`);

    for (let i = 0; i < data.length; ++i) {
        $("#repository-info").append(`<p class="p-1.5 ml-12">${data[i]["name"]}</p>`);
    }
}

function displayCommitInfo(data) {
    let commitTR =
        `
        <thead class="text-xs font-bold uppercase bg-gray-50 dark:bg-gray-700">
                <tr>
                    <th scope="col" class="sm:px-6 px-1 py-3">
                        SHA
                    </th>
                    <th scope="col" class="sm:px-6 px-2 py-3">
                        Timestamp
                    </th>
                    <th scope="col" class="sm:px-6 px-2 py-3">
                        Committer
                    </th>
                    <th scope="col" class="sm:px-6 px-2 py-3">
                        Commit Message
                    </th>
                </tr>
        </thead>
        `;

    $("#commits-info").append(commitTR);
    $("#commits-info").append("<tbody>");

    // where code was found for converting datetime to custom string https://stackoverflow.com/questions/27353047/convert-date-in-to-custom-format-in-javascript
    // console.log(moment.utc("2014-11-18T20:50:01.462Z").format('HH:mm YYYY-DD-MM'));
    /*
    if (data.length > 1) {
        for (let i = 0; i < data.length - 1; i++) {
            commitTR =
                `
                    <tr class="odd:bg-white odd:dark:bg-gray-900 even:bg-gray-50 even:dark:bg-gray-800 border-b dark:border-gray-700 hover:bg-gray-300 dark:hover:bg-gray-600">
                        <td class="sm:px-6 px-1 py-4">
                            <a href="${data[i]["htmlURL"]}" class="font-medium text-blue-600 dark:text-blue-300 hover:underline" target="_blank">
                                ${data[i]["sha"].substring(0, 8)}
                            </a>
                        </td>
                        <td class="sm:px-6 px-2 py-4">
                            ${moment.utc(data[i]["whenCommited"]).format('MMMM DD, YYYY HH:mm:ss')}
                        </td>
                        <td class="sm:px-6 px-2 py-4">
                            ${data[i]["commiter"]}
                        </td>
                        <td class="sm:px-6 px-2 py-4">
                            ${data[i]["commitMessage"]}
                        </td>
                    </tr>
                `;
            $("#commits-info").append(commitTR);
        }
    }
    */
    if (data.length > 1) {
        for (let i = 0; i < data.length - 1; i++) {
            commitTR =
                `
                    <tr class="odd:bg-white odd:dark:bg-gray-900 even:bg-gray-50 even:dark:bg-gray-800 border-b dark:border-gray-700 hover:bg-gray-300 dark:hover:bg-gray-600">
                        <td class="sm:px-6 px-1 py-4">
                            <a href="${data[i]["htmlURL"]}" class="font-medium text-blue-600 dark:text-blue-300 hover:underline" target="_blank">
                                ${data[i]["sha"].substring(0, 8)}
                            </a>
                        </td>
                        <td class="sm:px-6 px-2 py-4">
                            ${data[i]["whenCommited"]}
                        </td>
                        <td class="sm:px-6 px-2 py-4">
                            ${data[i]["commiter"]}
                        </td>
                        <td class="sm:px-6 px-2 py-4">
                            ${data[i]["commitMessage"]}
                        </td>
                    </tr>
                `;
            $("#commits-info").append(commitTR);
        }
    }
    else {
        commitTR =
                `
                    <tr class="odd:bg-white odd:dark:bg-gray-900 even:bg-gray-50 even:dark:bg-gray-800 border-b dark:border-gray-700 hover:bg-gray-300 dark:hover:bg-gray-600">
                        <td class="sm:px-6 px-1 py-4">
                            <a href="${data[0]["htmlURL"]}" class="font-medium text-blue-600 dark:text-blue-300 hover:underline" target="_blank">
                                ${data[0]["sha"].substring(0, 8)}
                            </a>
                        </td>
                        <td class="sm:px-6 px-2 py-4">
                            ${moment.utc(data[0]["whenCommited"]).format('MMMM DD, YYYY HH:mm:ss')}
                        </td>
                        <td class="sm:px-6 px-2 py-4">
                            ${data[0]["commiter"]}
                        </td>
                        <td class="sm:px-6 px-2 py-4">
                            ${data[0]["commitMessage"]}
                        </td>
                    </tr>
                `;
            $("#commits-info").append(commitTR);
    }

    $("#commits-info").append("</tbody>");
}

function displayRepoInfo(data) {
    $("#repository-info").append(`<h4 class="sm:text-2xl text-lg font-bold text-blue-800 dark:text-blue-200 pb-24 pl-1.5"><a href="${data["htmlURL"]}" target="_blank" id="repository-header"">${data["fullName"]}</a></h4>`);
    $("#repository-info").append(`<img class="sm:w-[216px] sm:h-[216px] w-[150px] h-[150px] 2xl:ml-[380px] xl:ml-[438px] lg:ml-[496px] md:ml-[415px] sm:ml-[350px] ml-[276px] mt-[-90px]" src="${data["ownerAvatarURL"]}" id="github-repo-image" alt="Repo Image"/>`);
    $("#repository-info").append(`<p class="p-1.5">Owner: ${data["owner"]}</p>`);
    $("#repository-info").append(`<p class="p-1.5">Last Updated: ${data["lastUpdated"]} day(s) ago`);

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
                $("#commits-header").show();

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