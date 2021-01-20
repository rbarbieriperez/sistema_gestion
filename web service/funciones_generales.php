<?php
    function GenerateRecuperationCode(){
       return bin2hex(random_bytes(5));
    }


?>