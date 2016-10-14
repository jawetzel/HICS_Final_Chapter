function filterFunction1Column() {
	
    var input = document.getElementById("myInput");
    var filter = input.value.toUpperCase();
    var splitFilter = filter.split(" ");
    var cleanedSplitFilter = splitFilter.filter(Boolean);

    var table = document.getElementById("dev-table");
    var tr = table.getElementsByTagName("tr");

    for (var i = 0; i < tr.length; i++) {
        tr[i].style.display = "";

        var column1 = tr[i].getElementsByTagName("td")[0];

        if (filter != "") {
            for (var j = 0; j < cleanedSplitFilter.length; j++) {
                if (column1) {
                    if ((CheckForMatch1(column1, cleanedSplitFilter[j]))
                        && (tr[i].style.display == "")) {
                        tr[i].style.display = "";
                    }
                    else if ((CheckForMatch1(column1, cleanedSplitFilter[j])) && (tr[i].style.display == "none")) {
                    }
                    else {
                            tr[i].style.display = "none";
                    }
                }
            }
        }
        else {
            tr[i].style.display = "";
        }
    }
}

function filterFunction2Column() {
	
    var input = document.getElementById("myInput");
    var filter = input.value.toUpperCase();
    var splitFilter = filter.split(" ");
    var cleanedSplitFilter = splitFilter.filter(Boolean);

    var table = document.getElementById("dev-table");
    var tr = table.getElementsByTagName("tr");

    for (var i = 0; i < tr.length; i++) {
        tr[i].style.display = "";
        var column1 = tr[i].getElementsByTagName("td")[0];
        var column2 = tr[i].getElementsByTagName("td")[1];
        if (filter != "") {
            for (var j = 0; j < cleanedSplitFilter.length; j++) {
                if (column1 || column2) {
                    if ((CheckForMatch2(column1, column2, cleanedSplitFilter[j]))
                        && (tr[i].style.display == "")) {
                        tr[i].style.display = "";
                    }
                    else if ((CheckForMatch2(column1, column2, cleanedSplitFilter[j])) && (tr[i].style.display == "none")) {
                    }
                    else {
                            tr[i].style.display = "none";
                    }
                }
            }
        }
        else {
            tr[i].style.display = "";
        }
    }
}
		
function filterFunction3Column() {
	
    var input = document.getElementById("myInput");
    var filter = input.value.toUpperCase();
    var splitFilter = filter.split(" ");
    var cleanedSplitFilter = splitFilter.filter(Boolean);

    var table = document.getElementById("dev-table");
    var tr = table.getElementsByTagName("tr");

    for (var i = 0; i < tr.length; i++) {
        tr[i].style.display = "";
        var column1 = tr[i].getElementsByTagName("td")[0];
        var column2 = tr[i].getElementsByTagName("td")[1];
        var column3 = tr[i].getElementsByTagName("td")[2];

        if (filter != "") {
            for (var j = 0; j < cleanedSplitFilter.length; j++) {
                if (column1 || column2 || column3) {
                    if ((CheckForMatch3(column1, column2, column3, cleanedSplitFilter[j]))
                        && (tr[i].style.display == "")) {
                        tr[i].style.display = "";
                    }
                    else if ((CheckForMatch3(column1, column2, column3, cleanedSplitFilter[j])) && (tr[i].style.display == "none")) {
                    }
                    else {
                            tr[i].style.display = "none";
                    }
                }
            }
        }
        else {
            tr[i].style.display = "";
        }
    }
}	
		
function filterFunction4Column() {
	
    var input = document.getElementById("myInput");
    var filter = input.value.toUpperCase();
    var splitFilter = filter.split(" ");
    var cleanedSplitFilter = splitFilter.filter(Boolean);

    var table = document.getElementById("dev-table");
    var tr = table.getElementsByTagName("tr");

    for (var i = 0; i < tr.length; i++) {
        tr[i].style.display = "";
        var column1 = tr[i].getElementsByTagName("td")[0];
        var column2 = tr[i].getElementsByTagName("td")[1];
        var column3 = tr[i].getElementsByTagName("td")[2];
        var column4 = tr[i].getElementsByTagName("td")[3];

        if (filter != "") {
            for (var j = 0; j < cleanedSplitFilter.length; j++) {
                if (column1 || column2 || column3 || column4) {
                    if ((CheckForMatch4(column1, column2, column3, column4, cleanedSplitFilter[j]))
                        && (tr[i].style.display == "")) {
                        tr[i].style.display = "";
                    }
                    else if ((CheckForMatch4(column1, column2, column3, column4, cleanedSplitFilter[j])) && (tr[i].style.display == "none")) {
                    }
                    else {
                            tr[i].style.display = "none";
                    }
                }
            }
        }
        else {
            tr[i].style.display = "";
        }
    }
}

function filterFunction5Column() {
	
    var input = document.getElementById("myInput");
    var filter = input.value.toUpperCase();
    var splitFilter = filter.split(" ");
    var cleanedSplitFilter = splitFilter.filter(Boolean);

    var table = document.getElementById("dev-table");
    var tr = table.getElementsByTagName("tr");

    for (var i = 0; i < tr.length; i++) {
        tr[i].style.display = "";
        var column1 = tr[i].getElementsByTagName("td")[0];
        var column2 = tr[i].getElementsByTagName("td")[1];
        var column3 = tr[i].getElementsByTagName("td")[2];
        var column4 = tr[i].getElementsByTagName("td")[3];
        var column5 = tr[i].getElementsByTagName("td")[4];

        if (filter != "") {
            for (var j = 0; j < cleanedSplitFilter.length; j++) {
                if (column1 || column2 || column3 || column4 || column5) {
                    if ((CheckForMatch5(column1, column2, column3, column4, column5, cleanedSplitFilter[j]))
                        && (tr[i].style.display == "")) {
                        tr[i].style.display = "";
                    }
                    else if ((CheckForMatch5(column1, column2, column3, column4, column5, cleanedSplitFilter[j])) && (tr[i].style.display == "none")) {
                    }
                    else {
                            tr[i].style.display = "none";
                    }
                }
            }
        }
        else {
            tr[i].style.display = "";
        }
    }
}
		
function filterFunction6Column() {
	
    var input = document.getElementById("myInput");
    var filter = input.value.toUpperCase();
    var splitFilter = filter.split(" ");
    var cleanedSplitFilter = splitFilter.filter(Boolean);

    var table = document.getElementById("dev-table");
    var tr = table.getElementsByTagName("tr");

    for (var i = 0; i < tr.length; i++) {
        tr[i].style.display = "";
        var column1 = tr[i].getElementsByTagName("td")[0];
        var column2 = tr[i].getElementsByTagName("td")[1];
        var column3 = tr[i].getElementsByTagName("td")[2];
        var column4 = tr[i].getElementsByTagName("td")[3];
        var column5 = tr[i].getElementsByTagName("td")[4];
        var column6 = tr[i].getElementsByTagName("td")[5];

        if (filter != "") {
            for (var j = 0; j < cleanedSplitFilter.length; j++) {
                if (column1 || column2 || column3 || column4 || column5 || column6) {
                    if ((CheckForMatch6(column1, column2, column3, column4, column5, column6, cleanedSplitFilter[j]))
                        && (tr[i].style.display == "")) {
                        tr[i].style.display = "";
                    }
                    else if ((CheckForMatch6(column1, column2, column3, column4, column5, column6, cleanedSplitFilter[j])) && (tr[i].style.display == "none")) {
                        }
                    else {
                            tr[i].style.display = "none";
                    }
                }
            }
        }
        else {
            tr[i].style.display = "";
        }
    }
}		
	
function filterFunction7Column() {
	
    var input = document.getElementById("myInput");
    var filter = input.value.toUpperCase();
    var splitFilter = filter.split(" ");
    var cleanedSplitFilter = splitFilter.filter(Boolean);

    var table = document.getElementById("dev-table");
    var tr = table.getElementsByTagName("tr");

    for (var i = 0; i < tr.length; i++) {
        tr[i].style.display = "";
        var column1 = tr[i].getElementsByTagName("td")[0];
        var column2 = tr[i].getElementsByTagName("td")[1];
        var column3 = tr[i].getElementsByTagName("td")[2];
        var column4 = tr[i].getElementsByTagName("td")[3];
        var column5 = tr[i].getElementsByTagName("td")[4];
        var column6 = tr[i].getElementsByTagName("td")[5];
        var column7 = tr[i].getElementsByTagName("td")[6];

        if (filter != "") {
            for (var j = 0; j < cleanedSplitFilter.length; j++) {
                if (column1 || column2 || column3 || column4 || column5 || column6 || column7) {
                    if ((CheckForMatch7(column1, column2, column3, column4, column5, column6, column7, cleanedSplitFilter[j]))
                        && (tr[i].style.display == "")) {
                        tr[i].style.display = "";
                    }
                    else if ((CheckForMatch7(column1, column2, column3, column4, column5, column6, column7, cleanedSplitFilter[j])) && (tr[i].style.display == "none")) {
                    }
                    else {
                            tr[i].style.display = "none";
                    }
                }
            }
        }
        else {
            tr[i].style.display = "";
        }
    }
}
	
function filterFunction8Column() {
	
    var input = document.getElementById("myInput");
    var filter = input.value.toUpperCase();
    var splitFilter = filter.split(" ");
    var cleanedSplitFilter = splitFilter.filter(Boolean);

    var table = document.getElementById("dev-table");
    var tr = table.getElementsByTagName("tr");

    for (var i = 0; i < tr.length; i++) {
        tr[i].style.display = "";
        var column1 = tr[i].getElementsByTagName("td")[0];
        var column2 = tr[i].getElementsByTagName("td")[1];
        var column3 = tr[i].getElementsByTagName("td")[2];
        var column4 = tr[i].getElementsByTagName("td")[3];
        var column5 = tr[i].getElementsByTagName("td")[4];
        var column6 = tr[i].getElementsByTagName("td")[5];
        var column7 = tr[i].getElementsByTagName("td")[6];
        var column8 = tr[i].getElementsByTagName("td")[7];

        if (filter != "") {
            for (var j = 0; j < cleanedSplitFilter.length; j++) {
                if (column1 || column2 || column3 || column4 || column5 || column6 || column7 || column8) {
                    if ((CheckForMatch8(column1, column2, column3, column4, column5, column6, column7, column8, cleanedSplitFilter[j]))
                        && (tr[i].style.display == "")) {
                        tr[i].style.display = "";
                    }
                    else if ((CheckForMatch8(column1, column2, column3, column4, column5, column6, column7, column8, cleanedSplitFilter[j])) && (tr[i].style.display == "none")) {
                    }
                    else {
                            tr[i].style.display = "none";
                    }
                }
            }
        }
        else {
            tr[i].style.display = "";
        }
    }
}	
	
function CheckForMatch1(column1, filter)
{
    return column1.innerHTML.toUpperCase().indexOf(filter) > -1;
}	
	
function CheckForMatch2(column1, column2, filter)
{
    return 	column1.innerHTML.toUpperCase().indexOf(filter) > -1
            || column2.innerHTML.toUpperCase().indexOf(filter) > -1;
}		
	
function CheckForMatch3(column1, column2, column3, filter)
{
    return 	column1.innerHTML.toUpperCase().indexOf(filter) > -1
            || column2.innerHTML.toUpperCase().indexOf(filter) > -1
            || column3.innerHTML.toUpperCase().indexOf(filter) > -1;
}	
		
function CheckForMatch4(column1, column2, column3, column4, filter)
{
    return 	column1.innerHTML.toUpperCase().indexOf(filter) > -1
            || column2.innerHTML.toUpperCase().indexOf(filter) > -1
            || column3.innerHTML.toUpperCase().indexOf(filter) > -1
            || column4.innerHTML.toUpperCase().indexOf(filter) > -1;
}

function CheckForMatch5(column1, column2, column3, column4, column5, filter)
{
    return 	column1.innerHTML.toUpperCase().indexOf(filter) > -1
            || column2.innerHTML.toUpperCase().indexOf(filter) > -1
            || column3.innerHTML.toUpperCase().indexOf(filter) > -1
            || column4.innerHTML.toUpperCase().indexOf(filter) > -1
            || column5.innerHTML.toUpperCase().indexOf(filter) > -1;
}		
	
function CheckForMatch6(column1, column2, column3, column4, column5, column6, filter)
{
    return 	column1.innerHTML.toUpperCase().indexOf(filter) > -1
            || column2.innerHTML.toUpperCase().indexOf(filter) > -1
            || column3.innerHTML.toUpperCase().indexOf(filter) > -1
            || column4.innerHTML.toUpperCase().indexOf(filter) > -1
            || column5.innerHTML.toUpperCase().indexOf(filter) > -1
            || column6.innerHTML.toUpperCase().indexOf(filter) > -1;
}		
	
function CheckForMatch7(column1, column2, column3, column4, column5, column6, column7, filter)
{
    return 	column1.innerHTML.toUpperCase().indexOf(filter) > -1
            || column2.innerHTML.toUpperCase().indexOf(filter) > -1
            || column3.innerHTML.toUpperCase().indexOf(filter) > -1
            || column4.innerHTML.toUpperCase().indexOf(filter) > -1
            || column5.innerHTML.toUpperCase().indexOf(filter) > -1
            || column6.innerHTML.toUpperCase().indexOf(filter) > -1
            || column7.innerHTML.toUpperCase().indexOf(filter) > -1;
}	
	
function CheckForMatch8(column1, column2, column3, column4, column5, column6, column7, column8, filter)
{
    return 	column1.innerHTML.toUpperCase().indexOf(filter) > -1
            || column2.innerHTML.toUpperCase().indexOf(filter) > -1
            || column3.innerHTML.toUpperCase().indexOf(filter) > -1
            || column4.innerHTML.toUpperCase().indexOf(filter) > -1
            || column5.innerHTML.toUpperCase().indexOf(filter) > -1
            || column6.innerHTML.toUpperCase().indexOf(filter) > -1
            || column7.innerHTML.toUpperCase().indexOf(filter) > -1
            || column8.innerHTML.toUpperCase().indexOf(filter) > -1;
}	