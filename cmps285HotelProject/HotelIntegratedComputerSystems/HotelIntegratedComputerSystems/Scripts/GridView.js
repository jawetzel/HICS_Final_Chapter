function pushValuesToEditorExists(tablerow, Destination1, Destination2, Destination3, Destination4, Destination5, Destination6, Destination7, Destination8, Value1, Value2, Value3, Value4, Value5, Value6, Value7, Value8) {
    Destination1.value = document.tablerow.getElementById(Value1).innerText;
    console.log(Value1);
    console.log(Value1.child);
    console.log(Value1.value);
    console.log(Value1.innerText);
    console.log(Value1.child.innerText);
    console.log(Value1.child.value);


    Destination2.value = Value2.value;
    Destination3.value = Value3.value;
    Destination4.value = Value4.value;
    Destination5.value = Value5.value;
    Destination6.value = Value6.value;
    Destination7.value = Value7.value;
    Destination8.value = Value8.value;
}

function pushValuesToEditorNonExistant() {

}