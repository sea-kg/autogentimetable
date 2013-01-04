<?
   include_once("config.php");   
   include_once("classDB.php");
   include_once("classBunch.php");
   include_once("top.php");
   print_top();
   
   $page = new pageBunch("rooms", "subjects");
   $page->print_page();
?>
