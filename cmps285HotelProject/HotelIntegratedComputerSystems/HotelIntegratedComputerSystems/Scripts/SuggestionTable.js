//used in booking/create

//for hiding/unhiding an element (in this case, intended for suggestion table)
function showTable(element) {
    if (element.style.display === "none") {
        element.style.display = "";
    }
    else {
        element.style.display = "none";
    }
}


//for copying clicked result to CustomerName and CustomerId fields
function copyTo(listName) {
    var outputName = document.getElementById("myInput");
    var outputId = document.getElementById("CustomerId");
    var td = listName.getElementsByTagName("td");
    outputName.value = td[0].innerText;
    outputId.value = td[1].innerText;
}
