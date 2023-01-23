var i=0,text;
text = "// WEB/GRAPHIC DESIGNER // CLOUD DEVELOPER"

function typing() {
    if(i<text.length){
        document.getElementById("text").innerHTML += text.charAt(i);
        i++;
        setTimeout(typing,80);
    }
}
typing();