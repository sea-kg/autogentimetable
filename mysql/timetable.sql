-- phpMyAdmin SQL Dump
-- version 3.4.10.1deb1
-- http://www.phpmyadmin.net
--
-- Host: localhost
-- Generation Time: Dec 22, 2012 at 02:00 AM
-- Server version: 5.5.28
-- PHP Version: 5.3.10-1ubuntu3.4

SET SQL_MODE="NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- Database: `timetable`
--

-- --------------------------------------------------------

--
-- Table structure for table `days`
--

CREATE TABLE IF NOT EXISTS `days` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(255) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 AUTO_INCREMENT=8 ;

--
-- Dumping data for table `days`
--

INSERT INTO `days` (`id`, `name`) VALUES
(1, '&#1055;&#1085;'),
(2, '&#1042;&#1090;'),
(3, '&#1057;&#1088;'),
(4, '&#1063;&#1090;'),
(5, '&#1055;&#1090;'),
(6, '&#1057;&#1073;'),
(7, '&#1042;&#1089;');

-- --------------------------------------------------------

--
-- Table structure for table `days_times`
--

CREATE TABLE IF NOT EXISTS `days_times` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `id_days` int(11) NOT NULL,
  `id_times` int(11) NOT NULL,
  `weight` int(11) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `id_uniq_days_times` (`id_days`,`id_times`),
  KEY `id_times` (`id_times`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 AUTO_INCREMENT=40 ;

--
-- Dumping data for table `days_times`
--

INSERT INTO `days_times` (`id`, `id_days`, `id_times`, `weight`) VALUES
(3, 1, 1, 1),
(4, 1, 2, 1),
(5, 1, 3, 1),
(6, 1, 4, 1),
(7, 1, 5, 1),
(8, 1, 6, 1),
(9, 2, 1, 1),
(10, 2, 2, 1),
(11, 2, 3, 1),
(12, 2, 4, 1),
(13, 2, 5, 1),
(14, 2, 6, 1),
(15, 3, 1, 1),
(16, 4, 1, 1),
(17, 5, 1, 1),
(19, 6, 1, 1),
(20, 3, 2, 1),
(21, 3, 3, 1),
(22, 3, 4, 1),
(23, 3, 5, 1),
(24, 3, 6, 1),
(25, 4, 2, 1),
(26, 4, 3, 1),
(27, 4, 4, 1),
(28, 4, 5, 1),
(29, 4, 6, 1),
(30, 5, 2, 1),
(31, 5, 3, 1),
(33, 5, 4, 1),
(34, 5, 5, 1),
(35, 5, 6, 1),
(36, 6, 2, 1),
(37, 6, 3, 1),
(38, 6, 4, 1),
(39, 6, 5, 1);

-- --------------------------------------------------------

--
-- Table structure for table `groups`
--

CREATE TABLE IF NOT EXISTS `groups` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(255) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 AUTO_INCREMENT=7 ;

--
-- Dumping data for table `groups`
--

INSERT INTO `groups` (`id`, `name`) VALUES
(2, '&#1075;&#1088;&#1091;&#1087;&#1087;&#1072; 520-1'),
(3, '&#1075;&#1088;&#1091;&#1087;&#1087;&#1072; 526-1'),
(4, '&#1075;&#1088;&#1091;&#1087;&#1087;&#1072; 526-2'),
(5, '&#1075;&#1088;&#1091;&#1087;&#1087;&#1072; 527-1'),
(6, '&#1075;&#1088;&#1091;&#1087;&#1087;&#1072; 527-2');

-- --------------------------------------------------------

--
-- Table structure for table `groups_subjects`
--

CREATE TABLE IF NOT EXISTS `groups_subjects` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `id_groups` int(11) NOT NULL,
  `id_subjects` int(11) NOT NULL,
  `weight` int(11) NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `id_uniq_groups_subjects` (`id_groups`,`id_subjects`),
  KEY `id_subjects` (`id_subjects`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 AUTO_INCREMENT=11 ;

--
-- Dumping data for table `groups_subjects`
--

INSERT INTO `groups_subjects` (`id`, `id_groups`, `id_subjects`, `weight`) VALUES
(1, 3, 6, 1),
(2, 3, 14, 1),
(3, 3, 7, 1),
(5, 3, 15, 1),
(6, 3, 10, 1),
(7, 3, 19, 2),
(8, 4, 20, 2),
(10, 4, 7, 2);

-- --------------------------------------------------------

--
-- Table structure for table `rooms`
--

CREATE TABLE IF NOT EXISTS `rooms` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(255) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 AUTO_INCREMENT=9 ;

--
-- Dumping data for table `rooms`
--

INSERT INTO `rooms` (`id`, `name`) VALUES
(1, '&#1083;&#1072;&#1073;. 401 &#1060;'),
(2, '&#1083;&#1077;&#1082;. &#1072;&#1091;&#1076;. 412 &#1060;'),
(3, '&#1083;&#1072;&#1073;. 407 &#1060;'),
(4, '&#1083;&#1072;&#1073;. 409 &#1060;'),
(5, '&#1083;&#1077;&#1082;. &#1072;&#1091;&#1076;. 421 &#1060;'),
(6, '&#1072;&#1091;&#1076;. 230 &#1060;'),
(8, '&#1072;&#1091;&#1076;. 217 &#1060;');

-- --------------------------------------------------------

--
-- Table structure for table `rooms_subjects`
--

CREATE TABLE IF NOT EXISTS `rooms_subjects` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `id_rooms` int(11) NOT NULL,
  `id_subjects` int(11) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `id_uniq_rooms_subjects` (`id_rooms`,`id_subjects`),
  KEY `id_subjects` (`id_subjects`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 AUTO_INCREMENT=26 ;

--
-- Dumping data for table `rooms_subjects`
--

INSERT INTO `rooms_subjects` (`id`, `id_rooms`, `id_subjects`) VALUES
(17, 1, 14),
(18, 1, 15),
(19, 1, 16),
(20, 1, 17),
(21, 1, 18),
(22, 1, 19),
(23, 1, 20),
(24, 1, 21),
(9, 2, 5),
(10, 2, 6),
(11, 2, 7),
(12, 2, 8),
(13, 2, 9),
(14, 2, 10),
(15, 2, 11),
(16, 2, 12),
(25, 5, 7);

-- --------------------------------------------------------

--
-- Table structure for table `subjects`
--

CREATE TABLE IF NOT EXISTS `subjects` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(256) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 AUTO_INCREMENT=22 ;

--
-- Dumping data for table `subjects`
--

INSERT INTO `subjects` (`id`, `name`) VALUES
(5, '&#1052;&#1072;&#1090;&#1077;&#1084;&#1072;&#1090;&#1080;&#1082;&#1072; (&#1083;&#1077;&#1082;&#1094;&#1080;&#1103;)'),
(6, '&#1050;&#1054;&#1048;&#1041;&#1040;&#1057; (&#1083;&#1077;&#1082;&#1094;&#1080;&#1103;)'),
(7, '&#1055;&#1054;&#1048;&#1041; (&#1083;&#1077;&#1082;&#1094;&#1080;&#1103;)'),
(8, '&#1058;&#1057;&#1048;&#1052;&#1047;&#1048; (&#1083;&#1077;&#1082;&#1094;&#1080;&#1103;)'),
(9, '&#1054;&#1054;&#1048;&#1041; (&#1083;&#1077;&#1082;&#1094;&#1080;&#1103;)'),
(10, '&#1044;&#1080;&#1089;&#1082;&#1088;&#1077;&#1090;&#1085;&#1072;&#1103; &#1052;&#1072;&#1090;&#1077;&#1084;&#1072;&#1090;&#1080;&#1082;&#1072; <br>(&#1083;&#1077;&#1082;&#1094;&#1080;&#1103;)'),
(11, '&#1050;&#1052;&#1047;&#1048; (&#1083;&#1077;&#1082;&#1094;&#1080;&#1103;)'),
(12, '&#1048;&#1085;&#1092;&#1086;&#1088;&#1084;&#1072;&#1090;&#1080;&#1082;&#1072; (&#1083;&#1077;&#1082;&#1094;&#1080;&#1103;)'),
(14, '&#1050;&#1054;&#1048;&#1041;&#1040;&#1057; (&#1087;&#1088;&#1072;&#1082;&#1090;&#1080;&#1082;&#1072;)'),
(15, '&#1055;&#1054;&#1048;&#1041; (&#1087;&#1088;&#1072;&#1082;&#1090;&#1080;&#1082;&#1072;)'),
(16, '&#1052;&#1072;&#1090;&#1077;&#1084;&#1072;&#1090;&#1080;&#1082;&#1072; (&#1087;&#1088;&#1072;&#1082;&#1090;&#1080;&#1082;&#1072;)'),
(17, '&#1058;&#1057;&#1048;&#1052;&#1047;&#1048; (&#1087;&#1088;&#1072;&#1082;&#1090;&#1080;&#1082;&#1072;)'),
(18, '&#1054;&#1054;&#1048;&#1041; (&#1087;&#1088;&#1072;&#1082;&#1090;&#1080;&#1082;&#1072;)'),
(19, '&#1044;&#1080;&#1089;&#1082;&#1088;&#1077;&#1090;&#1085;&#1072;&#1103; &#1052;&#1072;&#1090;&#1077;&#1084;&#1072;&#1090;&#1080;&#1082;&#1072; (&#1087;&#1088;&#1072;&#1082;&#1090;&#1080;&#1082;&#1072;)'),
(20, '&#1050;&#1052;&#1047;&#1048; (&#1087;&#1088;&#1072;&#1082;&#1090;&#1080;&#1082;&#1072;)'),
(21, '&#1048;&#1085;&#1092;&#1086;&#1088;&#1084;&#1072;&#1090;&#1080;&#1082;&#1072; (&#1087;&#1088;&#1072;&#1082;&#1090;&#1080;&#1082;&#1072;)');

-- --------------------------------------------------------

--
-- Table structure for table `teachers`
--

CREATE TABLE IF NOT EXISTS `teachers` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(255) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 AUTO_INCREMENT=11 ;

--
-- Dumping data for table `teachers`
--

INSERT INTO `teachers` (`id`, `name`) VALUES
(2, '&#1057;&#1086;&#1087;&#1086;&#1074; &#1052;. &#1040;.'),
(3, '&#1050;&#1086;&#1085;&#1077;&#1074; &#1040;. &#1040;.'),
(4, '&#1040;&#1092;&#1086;&#1085;&#1080;&#1085; &#1043;. &#1048;.'),
(5, '&#1044;&#1072;&#1074;&#1099;&#1076;&#1086;&#1074;&#1072; &#1045;. &#1052;.'),
(6, '&#1050;&#1088;&#1091;&#1095;&#1080;&#1085;&#1080;&#1085; &#1044;. &#1042;.'),
(7, '&#1045;&#1074;&#1089;&#1102;&#1090;&#1080;&#1085; &#1054;. &#1054;.'),
(8, '&#1063;&#1077;&#1088;&#1085;&#1099;&#1093; &#1044;. &#1042;.'),
(9, '&#1050;&#1086;&#1089;&#1090;&#1102;&#1095;&#1077;&#1085;&#1082;&#1086; &#1045;. &#1070;.'),
(10, '&#1052;&#1077;&#1083;&#1100;&#1085;&#1080;&#1082;&#1086;&#1074; &#1052;. &#1048;.');

-- --------------------------------------------------------

--
-- Table structure for table `teachers_subjects`
--

CREATE TABLE IF NOT EXISTS `teachers_subjects` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `id_teachers` int(11) NOT NULL,
  `id_subjects` int(11) NOT NULL,
  `weight` int(11) NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `id_uniq_teachers_subjects` (`id_teachers`,`id_subjects`),
  KEY `id_subjects` (`id_subjects`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 AUTO_INCREMENT=10 ;

--
-- Dumping data for table `teachers_subjects`
--

INSERT INTO `teachers_subjects` (`id`, `id_teachers`, `id_subjects`, `weight`) VALUES
(4, 2, 15, 4),
(5, 2, 7, 4),
(6, 7, 11, 4),
(7, 7, 20, 4),
(8, 5, 10, 4),
(9, 5, 19, 4);

-- --------------------------------------------------------

--
-- Table structure for table `times`
--

CREATE TABLE IF NOT EXISTS `times` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(255) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 AUTO_INCREMENT=7 ;

--
-- Dumping data for table `times`
--

INSERT INTO `times` (`id`, `name`) VALUES
(1, '08.50-10.25'),
(2, '10.40-12.15'),
(3, '13.15-14.50'),
(4, '15.00-16.35'),
(5, '16.45-18.20'),
(6, '18.30-20.05');

-- --------------------------------------------------------

--
-- Table structure for table `timetable`
--

CREATE TABLE IF NOT EXISTS `timetable` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `id_groups` int(11) NOT NULL,
  `id_subjects` int(11) NOT NULL,
  `id_teachers` int(11) NOT NULL,
  `id_rooms` int(11) NOT NULL,
  `id_days_times` int(11) NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `id_groups_days_times` (`id_groups`,`id_days_times`),
  UNIQUE KEY `id_rooms_days_times` (`id_rooms`,`id_days_times`),
  UNIQUE KEY `id_teachers_days_times` (`id_teachers`,`id_days_times`),
  UNIQUE KEY `id_subjects_days_times` (`id_subjects`,`id_days_times`),
  KEY `id_days_times` (`id_days_times`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 AUTO_INCREMENT=296 ;

--
-- Dumping data for table `timetable`
--

INSERT INTO `timetable` (`id`, `id_groups`, `id_subjects`, `id_teachers`, `id_rooms`, `id_days_times`) VALUES
(287, 3, 7, 2, 2, 3),
(288, 3, 15, 2, 1, 9),
(289, 3, 10, 5, 2, 15),
(290, 3, 19, 5, 1, 16),
(291, 3, 19, 5, 1, 17),
(292, 4, 20, 7, 1, 3),
(293, 4, 20, 7, 1, 15),
(294, 4, 7, 2, 2, 16),
(295, 4, 7, 2, 2, 17);

--
-- Constraints for dumped tables
--

--
-- Constraints for table `days_times`
--
ALTER TABLE `days_times`
  ADD CONSTRAINT `days_times_ibfk_1` FOREIGN KEY (`id_days`) REFERENCES `days` (`id`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `days_times_ibfk_2` FOREIGN KEY (`id_times`) REFERENCES `times` (`id`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `groups_subjects`
--
ALTER TABLE `groups_subjects`
  ADD CONSTRAINT `groups_subjects_ibfk_1` FOREIGN KEY (`id_subjects`) REFERENCES `subjects` (`id`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `groups_subjects_ibfk_2` FOREIGN KEY (`id_groups`) REFERENCES `groups` (`id`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `rooms_subjects`
--
ALTER TABLE `rooms_subjects`
  ADD CONSTRAINT `rooms_subjects_ibfk_1` FOREIGN KEY (`id_rooms`) REFERENCES `rooms` (`id`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `rooms_subjects_ibfk_2` FOREIGN KEY (`id_subjects`) REFERENCES `subjects` (`id`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `teachers_subjects`
--
ALTER TABLE `teachers_subjects`
  ADD CONSTRAINT `teachers_subjects_ibfk_1` FOREIGN KEY (`id_teachers`) REFERENCES `teachers` (`id`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `teachers_subjects_ibfk_2` FOREIGN KEY (`id_subjects`) REFERENCES `subjects` (`id`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `timetable`
--
ALTER TABLE `timetable`
  ADD CONSTRAINT `timetable_ibfk_1` FOREIGN KEY (`id_subjects`) REFERENCES `subjects` (`id`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `timetable_ibfk_2` FOREIGN KEY (`id_days_times`) REFERENCES `days_times` (`id`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `timetable_ibfk_3` FOREIGN KEY (`id_rooms`) REFERENCES `rooms` (`id`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `timetable_ibfk_4` FOREIGN KEY (`id_teachers`) REFERENCES `teachers` (`id`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `timetable_ibfk_5` FOREIGN KEY (`id_groups`) REFERENCES `groups` (`id`) ON DELETE CASCADE ON UPDATE CASCADE;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
