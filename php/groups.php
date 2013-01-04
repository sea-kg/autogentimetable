<?
   include_once("config.php");   
   include_once("classDB.php");
   include_once("classDictonary.php");
   include_once("top.php");
   print_top();
   
   $page = new pageDictonary("groups");
   $page->print_page();
?>
