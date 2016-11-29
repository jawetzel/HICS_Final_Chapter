function selectInput2()
{
        var input = "Booked";
        var tbody = document.getElementById("itemTable");
        var tr = tbody.getElementsByTagName("tr");

        for (var i = 0; i < tr.length; i++) {
            tr[i].style.display = "";
            var column1 = tr[i].getElementsByTagName("td")[0];
            var column2 = tr[i].getElementsByTagName("td")[1];
            var column3 = tr[i].getElementsByTagName("td")[2];
            var column4 = tr[i].getElementsByTagName("td")[3];
            var column5 = tr[i].getElementsByTagName("td")[4];
            var column6 = tr[i].getElementsByTagName("td")[5];
            var column7 = tr[i].getElementsByTagName("td")[6];

            var options = column7.children;

                
            if (column6.innerText === "Booked") {
                options[0].style.display = ""    
            }
            else {
                options[1].style.display = ""
            }
        }
}