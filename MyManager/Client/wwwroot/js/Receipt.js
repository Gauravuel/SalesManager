export function printBill() {
    $(".printhide").hide();
     window.print();
 
    $(".printhide").show();
}
export function PrintDiv() {
    var divContents = document.getElementById("innerdiv_1").innerHTML;
    var printWindow = window.open('', '', 'height=200,width=400');
    printWindow.document.write('<html><head><title>Print DIV Content</title>');
    printWindow.document.write('</head><body >');
    printWindow.document.write(divContents);
    printWindow.document.write('</body></html>');
    printWindow.document.close();
    printWindow.print();
}