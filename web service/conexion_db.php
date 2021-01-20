<?php
    $hostname = 'localhost'; // Máquina local 
    $database = 'pizzeria';
    $username = 'root';
    $password = '';

    // Conectarse a MySQL con extensión PDO
    try {
        $con = new PDO('mysql:host=' . $hostname . ';dbname=' . $database,
                $username, $password);
    } catch (PDOException $e) {
        print "¡Error!: " . $e->getMessage();
        die();
    }
?>