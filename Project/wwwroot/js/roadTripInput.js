const defaultTrip = document.querySelector('#RoadTripDefault');
const clearTrip = document.querySelector('#RoadTripClear');

const noun1 = document.getElementById('Noun1');
const adjective1 = document.getElementById('Adjective1');
const noun2 = document.getElementById('Noun2');
const adjective2 = document.getElementById('Adjective2');
const adjective3 = document.getElementById('Adjective3');
const verb1 = document.getElementById('Verb1');
const verb2 = document.getElementById('Verb2');
const number1 = document.getElementById('Number1');
const verb3 = document.getElementById("Verb3");
const adverb1 = document.getElementById("Adverb1");
const noun3 = document.getElementById("Noun3");
const color1 = document.getElementById("Color1");
const verb4 = document.getElementById("Verb4");
const noun4 = document.getElementById("Noun4");
const exclamation1 = document.getElementById("Exclamation1");
const verb5 = document.getElementById("Verb5");
const adverb2 = document.getElementById("Adverb2");
const noun5 = document.getElementById("Noun5");
const verb6 = document.getElementById("Verb6");
const verb7 = document.getElementById("Verb7");
const noun6 = document.getElementById("Noun6");
const pluralNoun1 = document.getElementById('PluralNoun1');
const verb8 = document.getElementById("Verb8");
const name1 = document.getElementById('Name1');
const verb9 = document.getElementById("Verb9");
const noun7 = document.getElementById("Noun7");
const verb10 = document.getElementById("Verb10");
const adjective4 = document.getElementById("Adjective4");
const adverb3 = document.getElementById("Adverb3");
const adverb4 = document.getElementById("Adverb4");
const noun8 = document.getElementById("Noun8");
const verb11 = document.getElementById("Verb11");
const noun9 = document.getElementById("Noun9");
const adjective5 = document.getElementById("Adjective5");

defaultTrip.addEventListener('click', function()
{
    if (noun1.getAttribute("value") === '')
    {
        noun1.setAttribute("value", "CAR");
    }

    if (adjective1.getAttribute("value") === '')
    {
        adjective1.setAttribute("value", "AMAZING");
    }

    if (noun2.getAttribute("value") === '')
    {
        noun2.setAttribute("value", "PARK");
    }

    if (adjective2.getAttribute("value") === '')
    {
        adjective2.setAttribute("value", "CAR");
    }

    if (adjective3.getAttribute("value") === '')
    {
        adjective3.setAttribute("value", "GREEN");
    }

    if (verb1.getAttribute("value") === '')
    {
        verb1.setAttribute("value", "JUMPED");
    }

    if (verb2.getAttribute("value") === '')
    {
        verb2.setAttribute("value", "RAN");
    }

    if (number1.getAttribute("value") === '0')
    {
        number1.setAttribute("value", 15);
    }

    if (verb3.getAttribute("value") === '')
    {
        verb3.setAttribute("value", "RAN");
    }

    if (adverb1.getAttribute("value") === '')
    {
        adverb1.setAttribute("value", "QUICKLY")
    }

    if (noun3.getAttribute("value") === '')
    {
        noun3.setAttribute("value", "ROAD");
    }

    if (color1.getAttribute("value") === '')
    {
        color1.setAttribute("value", "GREEN");
    }

    if (verb4.getAttribute("value") === '')
    {
        verb4.setAttribute("value", "JUMPED");
    }

    if (noun4.getAttribute("value") === '')
    {
        noun4.setAttribute("value", "COFFEE");
    }

    if (exclamation1.getAttribute("value") === '')
    {
        exclamation1.setAttribute("value", "NO");
    }

    if (verb5.getAttribute("value") === '')
    {
        verb5.setAttribute("value", "YELLING");
    }

    if (adverb2.getAttribute("value") === '')
    {
        adverb2.setAttribute("value", "QUICKLY");
    }

    if (noun5.getAttribute("value") === '')
    {
        noun5.setAttribute("value", "CAR");
    }

    if (verb6.getAttribute("value") === '')
    {
        verb6.setAttribute("value", "SWERVED");
    }

    if (verb7.getAttribute("value") === '')
    {
        verb7.setAttribute("value", "JUMPED");
    }

    if (noun6.getAttribute("value") === '')
    {
        noun6.setAttribute("value", "WINDSHIELD");
    }

    if (pluralNoun1.getAttribute("value") === '')
    {
        pluralNoun1.setAttribute("value", "BREAKS");
    }

    if (verb8.getAttribute("value") === '')
    {
        verb8.setAttribute("value", "SURPRISED");
    }

    if (name1.getAttribute("value") === '')
    {
        name1.setAttribute("value", "BILL");
    }

    if (verb9.getAttribute("value") === '')
    {
        verb9.setAttribute("value", "LEAP");
    }

    if (noun7.getAttribute("value") === '')
    {
        noun7.setAttribute("value", "KANGAROO")
    }

    if (verb10.getAttribute("value") === '')
    {
        verb10.setAttribute("value", "DASHED");
    }

    if (adjective4.getAttribute("value") === '')
    {
        adjective4.setAttribute("value", "GREEN");
    }

    if (adverb3.getAttribute("value") === '')
    {
        adverb3.setAttribute("value", "QUICKLY");
    }

    if (adverb4.getAttribute("value") === '')
    {
        adverb4.setAttribute("value", "BLINDLY");
    }

    if (noun8.getAttribute("value") === '')
    {
        noun8.setAttribute("value", "CAR");
    }

    if (verb11.getAttribute("value") === '')
    {
        verb11.setAttribute("value", "TRIP")
    }

    if (noun9.getAttribute("value") === '')
    {
        noun9.setAttribute("value", "PARK");
    }

    if (adjective5.getAttribute("value") === '')
    {
        adjective5.setAttribute("value", "CRAZY");
    }
});

clearTrip.addEventListener('click', function()
{
    noun1.setAttribute("value", "");
    adjective1.setAttribute("value", "");
    noun2.setAttribute("value", "");
    adjective2.setAttribute("value", "");
    adjective3.setAttribute("value", "");
    verb1.setAttribute("value", "");
    verb2.setAttribute("value", "");
    number1.setAttribute("value", "0");
    verb3.setAttribute("value", "");
    adverb1.setAttribute("value", "");
    noun3.setAttribute("value", "");
    color1.setAttribute("value", "");
    verb4.setAttribute("value", "");
    noun4.setAttribute("value", "");
    exclamation1.setAttribute("value", "");
    verb5.setAttribute("value", "");
    adverb2.setAttribute("value", "");
    noun5.setAttribute("value", "");
    verb6.setAttribute("value", "");
    verb7.setAttribute("value", "");
    noun6.setAttribute("value", "");
    pluralNoun1.setAttribute("value", "");
    verb8.setAttribute("value", "");
    name1.setAttribute("value", "");
    verb9.setAttribute("value", "");
    noun7.setAttribute("value", "");
    verb10.setAttribute("value", "");
    adjective4.setAttribute("value", "");
    adverb3.setAttribute("value", "");
    adverb4.setAttribute("value", "");
    noun8.setAttribute("value", "");
    verb11.setAttribute("value", "");
    noun9.setAttribute("value", "");
    adjective5.setAttribute("value", "");
});