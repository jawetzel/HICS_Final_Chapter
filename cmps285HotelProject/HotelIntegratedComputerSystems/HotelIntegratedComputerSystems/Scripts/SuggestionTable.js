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


function forwardTo(row, listName) {

    var tablerow = row.getElementsByTagName("td");
    document.getElementById("MaintenanceLog_BuildingName").value = tablerow[0].innerText;
    document.getElementById("MaintenanceLog_Floor").value = tablerow[1].innerText;
    document.getElementById("MaintenanceLog_RoomNumber").value = tablerow[2].innerText;
    document.getElementById("MaintenanceLog_RoomId").value = tablerow[3].innerText;
    showTable(listName);
}