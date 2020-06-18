function encodeAndDecodeMessages() {
    document.getElementsByTagName('button')[0].addEventListener('click', encode);
    document.getElementsByTagName('button')[1].addEventListener('click', decode);
    function encode(){
        let encode = document.getElementsByTagName('textarea')[0].value;
        let encoded = '';
        for(let i=0; i<encode.length; i++){
            encoded += String.fromCharCode((encode.charCodeAt(i) + 1));
        }
        document.getElementsByTagName('textarea')[1].value = encoded;
        document.getElementsByTagName('textarea')[0].value = '';
    }
    function decode(){
        let decode = document.getElementsByTagName('textarea')[1].value;
        let decoded = '';
        for(let i=0; i<decode.length; i++){
            decoded += String.fromCharCode((decode.charCodeAt(i) - 1));
        }
        document.getElementsByTagName('textarea')[1].value = decoded;
    }
}