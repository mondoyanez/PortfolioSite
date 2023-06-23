const defaultCamp = document.querySelector('#CampDefault');
const clearCamp = document.querySelector('#CampClear');

const name1 = document.getElementById('Name1');
const campName1 = document.getElementById('CampName1');
const adjective1 = document.getElementById('Adjective1');
const activity1 = document.getElementById('Activity1');
const activity2 = document.getElementById('Activity2');
const pluralNoun1 = document.getElementById('PluralNoun1');
const adjective2 = document.getElementById('Adjective2');
const noun1 = document.getElementById('Noun1');
const nickName1 = document.getElementById('NickName1');

defaultCamp.addEventListener('click', function()
{
    if (name1.getAttribute("value") === '')
    {
        name1.setAttribute("value", "Mary");
    }
    
    if (campName1.getAttribute("value") === '')
    {
        campName1.setAttribute("value", "Dakota");
    }

    if (adjective1.getAttribute("value") === '')
    {
        adjective1.setAttribute("value", "great");
    }

    if (activity1.getAttribute("value") === '')
    {
        activity1.setAttribute("value", "fishing");
    }

    if (activity2.getAttribute("value") === '')
    {
        activity2.setAttribute("value", "rafting");
    }

    if (pluralNoun1.getAttribute("value") === '')
    {
        pluralNoun1.setAttribute("value", "s'mores");
    }

    if (adjective2.getAttribute("value") === '')
    {
        adjective2.setAttribute("value", "tasty");
    }

    if (noun1.getAttribute("value") === '')
    {
        noun1.setAttribute("value", "a lot");
    }

    if (nickName1.getAttribute("value") === '')
    {
        nickName1.setAttribute("value", "Lioness");
    }

});

clearCamp.addEventListener('click', function()
{
    name1.setAttribute("value", "");
    campName1.setAttribute("value", "");
    adjective1.setAttribute("value", "");
    activity1.setAttribute("value", "");
    activity2.setAttribute("value", "");
    pluralNoun1.setAttribute("value", "");
    adjective2.setAttribute("value", "");
    noun1.setAttribute("value", "");
    nickName1.setAttribute("value", "");
});