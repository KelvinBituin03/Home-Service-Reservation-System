-- phpMyAdmin SQL Dump
-- version 4.5.1
-- http://www.phpmyadmin.net
--
-- Host: 127.0.0.1
-- Generation Time: Mar 06, 2017 at 07:52 AM
-- Server version: 10.1.8-MariaDB
-- PHP Version: 5.6.14

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `dbsystem`
--

-- --------------------------------------------------------

--
-- Table structure for table `tblcstmr`
--

CREATE TABLE `tblcstmr` (
  `ClientID` int(11) NOT NULL,
  `fname` varchar(20) CHARACTER SET utf8 NOT NULL,
  `mname` varchar(20) CHARACTER SET utf8 NOT NULL,
  `lname` varchar(20) CHARACTER SET utf8 NOT NULL,
  `age` int(3) NOT NULL,
  `address` varchar(100) CHARACTER SET utf8 NOT NULL,
  `ContactNo` bigint(13) NOT NULL,
  `Gender` varchar(8) CHARACTER SET utf8 NOT NULL,
  `FULLNAME` varchar(50) CHARACTER SET utf16 NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COMMENT='Table for Customers';

--
-- Dumping data for table `tblcstmr`
--

INSERT INTO `tblcstmr` (`ClientID`, `fname`, `mname`, `lname`, `age`, `address`, `ContactNo`, `Gender`, `FULLNAME`) VALUES
(10004, 'Banjo', 'Dimayacyac', 'Rondilla', 16, '4046 General Luna st. South Cembo Makati City', 9161231231, 'Male', 'Rondilla, Banjo Dimayacyac'),
(10006, 'Rojj', 'Seeeeett', 'Tonnn', 26, '123094 del pilar st makati2', 9666666663, 'Male', 'Ton, Rojette Se'),
(10008, 'Michael', 'minero', 'Pinero', 22, '4022 camito st brgy cembo makati city', 9976996619, 'Male', 'Pinero, Michael minero'),
(10009, 'Joshua', 'Hellyer', 'Purgatorio', 22, '6822 block 6 BCDA Taguig city', 9652956621, 'Male', 'Purgatorio, Joshua Hellyer'),
(10010, 'Mason', 'Franklin', 'Lopez', 23, '6834 block 4 skwater house city', 9232622222, 'Male', 'Lopez, Mason Franklin'),
(10011, 'Joson', 'Getrekt', 'Franklin', 23, '4022 General Del Pilar st BRGY South Cembo Makati City', 9564765529, 'Male', 'Franklin, Joson Getrekt'),
(10013, 'Alaine', 'Victor', 'Sison', 29, '3321 block 12 st. of blacks laguna', 9662837692, 'Female', 'Sison, Alaine Victor'),
(10014, 'Joanna', 'Bkoszx', 'Hanna', 29, '6732 caimito st. cembo makati city', 9652623189, 'Female', 'Hanna, Joanna Bkoszx'),
(10015, 'Kinhwa', 'Mtoun', 'Zafar', 33, '6032 kalayaan st. ayala alabang', 9687392123, 'Female', 'Zafar, Kinhwa Mtoun'),
(10016, 'Ygor', 'Exlp', 'Recnmo', 0, '40670 del pilar south taguig', 9158328973, 'Female', 'Recnmo, Ygor Exlp');

-- --------------------------------------------------------

--
-- Table structure for table `tblemp`
--

CREATE TABLE `tblemp` (
  `EmpID` int(11) NOT NULL,
  `fname` varchar(20) CHARACTER SET utf8 NOT NULL,
  `mname` varchar(20) CHARACTER SET utf8 NOT NULL,
  `lname` varchar(20) CHARACTER SET utf8 NOT NULL,
  `age` int(3) NOT NULL,
  `address` varchar(100) CHARACTER SET utf8 NOT NULL,
  `ContactNo` bigint(13) NOT NULL,
  `Position` varchar(25) CHARACTER SET utf8 NOT NULL,
  `Gender` varchar(8) CHARACTER SET utf8 NOT NULL,
  `FULLNAME` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COMMENT='Table for Employees';

--
-- Dumping data for table `tblemp`
--

INSERT INTO `tblemp` (`EmpID`, `fname`, `mname`, `lname`, `age`, `address`, `ContactNo`, `Position`, `Gender`, `FULLNAME`) VALUES
(20005, 'relly', 'ac', 'acoba', 44, '5922 General ricarte st south cembo makati', 9546755891, 'Therapist', 'Male', 'acoba, relly ac'),
(20006, 'ponce', 'ema', 'man', 32, 'Block 777 soysauce st YellowBee taguig', 9322718556, 'Beautician', 'Female', 'man, ponce ema'),
(20007, 'cliff', 'iyot', 'mang', 32, 'block 666 orange st taguig', 9153276124, 'Beautician', 'Male', 'mang, cliff iyot'),
(20008, 'pong', 'gers', 'popo', 32, '8821 Block 41 joy st. pasig city', 9548794625, 'Therapist', 'Male', 'popo, pong gers'),
(20009, 'Hannah', 'boss', 'Ermina', 55, '9866 f8 st brgy canal taguig city', 9328962511, 'Driver', 'Male', 'Ermina, Hannah boss'),
(20010, 'Carl', 'boy', 'arcana', 50, 'Block 22 manggahan st taguig city', 9326428871, 'Driver', 'Female', 'arcana, Carl boy'),
(20011, 'Pidgeoto', 'Ja', 'Roh', 66, '4046 bllock 4 makati taguig', 9642177421, 'Driver', 'Female', 'Roh, Pidgeoto Ja'),
(20012, 'Mistere', 'kalboo', 'cleann', 23, 'cykablyat st3', 9075523111, 'Receptionist', 'Female', 'clean, Mister kalbo'),
(20014, 'Egay', 'Shadow', 'Fiend', 24, '6621 bluesteel st. brgy classvert taguig city', 9157322711, 'Beautician', 'Female', 'Fiend, Egay Shadow'),
(20015, 'Megalodon', 'Verxo', 'Agapito', 24, '7532 blueshark st. brgy greatwhite dagupan city', 9632186772, 'Therapist', 'Female', 'Agapito, Megalodon Verxo');

-- --------------------------------------------------------

--
-- Table structure for table `tblservices`
--

CREATE TABLE `tblservices` (
  `ServiceID` int(5) NOT NULL,
  `ServiceName` varchar(50) NOT NULL,
  `ServiceType` varchar(50) NOT NULL,
  `Price` decimal(10,2) NOT NULL,
  `Duration` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf32;

--
-- Dumping data for table `tblservices`
--

INSERT INTO `tblservices` (`ServiceID`, `ServiceName`, `ServiceType`, `Price`, `Duration`) VALUES
(1, 'Full Body Massage', 'Massage', '250.00', '60 minutes'),
(2, 'Foot Reflex', 'Massage', '250.00', '60 minutes'),
(3, 'Foot Spa', 'Massage', '350.00', '60 minutes'),
(4, 'Body Scrub', 'Massage', '350.00', '59 minutes'),
(5, 'Bentosa with Massage', 'Massage', '500.00', '60 minutes'),
(6, 'Hot Stone', 'Massage', '500.00', '60 minutes'),
(8, 'Hair Dye', 'Hair', '250.00', '60 minutes'),
(9, 'Hot Oil', 'Hair', '250.00', '60 minutes'),
(10, 'Blow Dry', 'Hair', '250.00', '60 minutes'),
(11, 'Mens Full Back Waxing', 'Waxing', '300.00', '60 minutes'),
(12, 'Half Legs Waxing', 'Waxing', '350.00', '60 minutes'),
(13, 'Half Arm Waxing', 'Waxing', '300.00', '60 minutes'),
(14, 'Mens Chest Waxing', 'Waxing', '250.00', '60 minutes'),
(15, 'Underarm Waxing', 'Waxing', '250.00', '60 minutes'),
(16, 'Eyebrow Waxing', 'Waxing', '200.00', '60 minutes'),
(17, 'Full Legs Waxing', 'Waxing', '500.00', '60 minutes'),
(18, 'Full Arm Waxing', 'Waxing', '350.00', '60 minutes'),
(19, 'Brazillian Waxing', 'Waxing', '500.00', '60 minutes'),
(20, 'Upper Lip Waxing', 'Waxing', '150.00', '60 minutes'),
(21, 'Bikini Waxing', 'Waxing', '400.00', '60 minutes'),
(22, 'Threading Waxing', 'Waxing', '200.00', '60 minutes'),
(23, 'Manicure and Pedicure', 'Massage', '250.00', '60 minutes'),
(26, 'test23w2', 'Massage', '350.00', '30 minutes'),
(27, 'face massage', 'Massage', '200.00', '60 minutes'),
(28, 'test5', 'Massage', '230.00', '50minutes'),
(29, 'test6', 'Massage', '321.00', '35 minutes'),
(30, 'test22', 'Massage', '300.00', '32 minutes'),
(33, 'test9', 'Waxing', '3923.00', '32 minutes'),
(34, 'testlangjan122017', 'Massage', '600.00', '60 minutes');

-- --------------------------------------------------------

--
-- Table structure for table `tbltest`
--

CREATE TABLE `tbltest` (
  `price` double(10,2) NOT NULL,
  `DateOfService` varchar(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf16;

--
-- Dumping data for table `tbltest`
--

INSERT INTO `tbltest` (`price`, `DateOfService`) VALUES
(2.00, ''),
(21.00, ''),
(21.00, ''),
(321.00, ''),
(25.00, '09/29/2016'),
(30.00, '10/05/2016'),
(35.00, '09/05/2016'),
(30.00, '10/24/2016');

-- --------------------------------------------------------

--
-- Table structure for table `tbltrans`
--

CREATE TABLE `tbltrans` (
  `No` int(4) NOT NULL,
  `TransID` int(100) NOT NULL,
  `Service` varchar(50) CHARACTER SET utf8 NOT NULL,
  `Price` decimal(10,2) NOT NULL,
  `StartTime` varchar(10) CHARACTER SET utf8 NOT NULL,
  `EndTime` varchar(10) CHARACTER SET utf8 NOT NULL,
  `StartTimeSession` varchar(5) CHARACTER SET utf8 NOT NULL,
  `EndTimeSession` varchar(5) CHARACTER SET utf8 NOT NULL,
  `ClientID` int(11) NOT NULL,
  `FULLNAME` varchar(50) NOT NULL,
  `AssignedEmp` varchar(50) NOT NULL,
  `AssignedDriver` varchar(50) CHARACTER SET utf8 NOT NULL,
  `DateMade` varchar(12) CHARACTER SET utf8 NOT NULL,
  `st` varchar(50) NOT NULL,
  `et` varchar(50) NOT NULL,
  `Status` varchar(50) NOT NULL,
  `DateOfService` varchar(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COMMENT='Table to be joined to tblcstmr';

--
-- Dumping data for table `tbltrans`
--

INSERT INTO `tbltrans` (`No`, `TransID`, `Service`, `Price`, `StartTime`, `EndTime`, `StartTimeSession`, `EndTimeSession`, `ClientID`, `FULLNAME`, `AssignedEmp`, `AssignedDriver`, `DateMade`, `st`, `et`, `Status`, `DateOfService`) VALUES
(1, 1, 'Full Body Massage', '250.00', '1 00 PM', '2 00 PM', 'PM', 'PM', 10004, 'Rondilla, Banjo Dimayacyac', 'acoba, relly ac', 'arcana, Carl boy', '03/01/2017', '100', '200', '', '03/02/2017'),
(3, 2, 'Foot Reflex', '250.00', '2 00 PM', '3 00 PM', 'PM', 'PM', 10011, 'Franklin, Joson Getrekt', 'acoba, relly ac', 'Ermina, Hannah boss', '03/01/2017', '200', '300', '', '03/02/2017'),
(5, 3, 'Full Body Massage', '250.00', '1 00 PM', '2 00 PM', 'PM', 'PM', 10004, 'Rondilla, Banjo Dimayacyac', 'Agapito, Megalodon Verxo', 'Roh, Pidgeoto Ja', '03/01/2017', '100', '200', '', '03/02/2017'),
(6, 3, 'Full Body Massage', '250.00', '3 00 PM', '4 00 PM', 'PM', 'PM', 10004, 'Rondilla, Banjo Dimayacyac', 'popo, pong gers', 'arcana, Carl boy', '03/01/2017', '300', '400', '', '03/02/2017'),
(11, 4, 'Full Body Massage', '250.00', '5 00 PM', '6 00 PM', 'PM', 'PM', 10011, 'Franklin, Joson Getrekt', 'acoba, relly ac', 'arcana, Carl boy', '03/03/2017', '500', '600', '', '03/03/2017'),
(12, 5, 'Foot Reflex', '250.00', '2 00 PM', '3 00 PM', 'PM', 'PM', 10014, 'Hanna, Joanna Bkoszx', 'acoba, relly ac', 'Ermina, Hannah boss', '03/03/2017', '200', '300', '', '03/23/2017'),
(13, 6, 'Full Body Massage', '250.00', '1 00 PM', '2 00 PM', 'PM', 'PM', 10011, 'Franklin, Joson Getrekt', 'Agapito, Megalodon Verxo', 'arcana, Carl boy', '03/03/2017', '100', '200', '', '03/16/2017'),
(14, 7, 'Foot Reflex', '250.00', '3 00 PM', '4 00 PM', 'PM', 'PM', 10011, 'Franklin, Joson Getrekt', 'acoba, relly ac', 'arcana, Carl boy', '03/05/2017', '300', '400', '', '03/05/2017');

-- --------------------------------------------------------

--
-- Table structure for table `tbltrans2`
--

CREATE TABLE `tbltrans2` (
  `No` int(4) NOT NULL,
  `TransID` int(100) NOT NULL,
  `Service` varchar(50) CHARACTER SET utf8 NOT NULL,
  `Price` decimal(10,2) NOT NULL,
  `StartTime` varchar(10) CHARACTER SET utf8 NOT NULL,
  `EndTime` varchar(10) CHARACTER SET utf8 NOT NULL,
  `StartTimeSession` varchar(5) CHARACTER SET utf8 NOT NULL,
  `EndTimeSession` varchar(5) CHARACTER SET utf8 NOT NULL,
  `ClientID` int(11) NOT NULL,
  `FULLNAME` varchar(50) NOT NULL,
  `AssignedEmp` varchar(50) NOT NULL,
  `AssignedDriver` varchar(50) CHARACTER SET utf8 NOT NULL,
  `DateMade` varchar(12) CHARACTER SET utf8 NOT NULL,
  `st` varchar(50) NOT NULL,
  `et` varchar(50) NOT NULL,
  `Status` varchar(50) NOT NULL,
  `DateCancelled` varchar(15) NOT NULL,
  `DateOfService` varchar(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COMMENT='Table to be joined to tblcstmr';

--
-- Dumping data for table `tbltrans2`
--

INSERT INTO `tbltrans2` (`No`, `TransID`, `Service`, `Price`, `StartTime`, `EndTime`, `StartTimeSession`, `EndTimeSession`, `ClientID`, `FULLNAME`, `AssignedEmp`, `AssignedDriver`, `DateMade`, `st`, `et`, `Status`, `DateCancelled`, `DateOfService`) VALUES
(1, 1, 'Full Body Massage', '250.00', '1 00', '2 00', 'PM', 'PM', 10004, 'Rondilla, Banjo Dimayacyac', 'acoba, relly ac', 'arcana, Carl boy', '03/01/2017', '100', '200', '', '', '03/02/2017');

-- --------------------------------------------------------

--
-- Table structure for table `tbltranscancelled`
--

CREATE TABLE `tbltranscancelled` (
  `TransID` int(100) NOT NULL,
  `Service` varchar(50) CHARACTER SET utf8 NOT NULL,
  `StartTime` varchar(10) CHARACTER SET utf8 NOT NULL,
  `EndTime` varchar(10) CHARACTER SET utf8 NOT NULL,
  `StartTimeSession` varchar(5) CHARACTER SET utf8 NOT NULL,
  `EndTimeSession` varchar(5) CHARACTER SET utf8 NOT NULL,
  `ClientID` int(11) NOT NULL,
  `FULLNAME` varchar(50) NOT NULL,
  `AssignedEmp` varchar(20) NOT NULL,
  `AssignedDriver` varchar(20) CHARACTER SET utf8 NOT NULL,
  `DateMade` varchar(12) CHARACTER SET utf8 NOT NULL,
  `st` varchar(50) NOT NULL,
  `et` varchar(50) NOT NULL,
  `Status` varchar(50) NOT NULL,
  `DateOfService` varchar(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COMMENT='Table to be joined to tblcstmr';

-- --------------------------------------------------------

--
-- Table structure for table `users`
--

CREATE TABLE `users` (
  `Username` varchar(20) CHARACTER SET utf8 NOT NULL,
  `Password` varchar(20) CHARACTER SET utf8 NOT NULL,
  `SecretQuestion` varchar(50) CHARACTER SET utf8 NOT NULL,
  `SecretAnswer` varchar(50) CHARACTER SET utf8 NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COMMENT='This Table is for the Receptionist of our system';

--
-- Dumping data for table `users`
--

INSERT INTO `users` (`Username`, `Password`, `SecretQuestion`, `SecretAnswer`) VALUES
('a', 'a', 'What is your first pet name ?', 'mitch'),
('admin', 'admin', 'What is your first pet name ?', 'mitch'),
('banjo', 'rdonilla', 'What is the first name of your first teacher?', 'ehh');

-- --------------------------------------------------------

--
-- Table structure for table `userslogin`
--

CREATE TABLE `userslogin` (
  `UserLogNumber` int(10) NOT NULL,
  `Username` varchar(25) NOT NULL,
  `TimeIn` varchar(60) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf16;

--
-- Dumping data for table `userslogin`
--

INSERT INTO `userslogin` (`UserLogNumber`, `Username`, `TimeIn`) VALUES
(1, 'admin', '2/15/2017 7:14:36 AM'),
(2, 'admin', '2/15/2017 7:16:37 AM'),
(3, 'admin', '2/15/2017 7:17:25 AM'),
(4, 'admin', '2/15/2017 7:18:14 AM'),
(5, 'admin', '2/15/2017 7:19:08 AM'),
(6, 'admin', '2/15/2017 7:21:37 AM'),
(7, 'admin', '2/15/2017 7:23:05 AM'),
(8, 'admin', '2/15/2017 7:23:55 AM'),
(9, 'admin', '2/15/2017 7:25:50 AM'),
(10, 'admin', '2/15/2017 7:29:07 AM'),
(11, 'admin', '2/15/2017 7:30:14 AM'),
(12, 'admin', '2/15/2017 7:30:40 AM'),
(13, 'admin', '2/15/2017 7:31:37 AM'),
(14, 'admin', '2/15/2017 7:34:23 AM'),
(15, 'admin', '2/15/2017 7:36:11 AM'),
(16, 'admin', '2/15/2017 7:39:09 AM'),
(17, 'a', '2/15/2017 8:21:03 AM'),
(18, 'admin', '2/15/2017 8:25:11 AM'),
(19, 'admin', '2/15/2017 8:26:24 AM'),
(20, 'admin', '2/15/2017 8:27:36 AM'),
(21, 'admin', '2/15/2017 8:28:37 AM'),
(22, 'admin', '2/15/2017 8:33:54 AM'),
(23, 'admin', '2/15/2017 8:39:25 AM'),
(24, 'admin', '2/15/2017 8:42:33 AM'),
(25, 'admin', '2/15/2017 4:13:28 PM'),
(26, 'admin', '2/15/2017 4:16:40 PM'),
(27, 'a', '2/15/2017 4:16:43 PM'),
(28, 'admin', '2/15/2017 4:17:21 PM'),
(29, 'admin', '2/15/2017 4:22:43 PM'),
(30, 'admin', '2/15/2017 4:23:30 PM'),
(31, 'admin', '2/15/2017 4:25:03 PM'),
(32, 'admin', '3/3/2017 2:27:18 AM'),
(33, 'admin', '3/3/2017 2:27:48 AM'),
(34, 'admin', '3/3/2017 2:28:50 AM'),
(35, 'a', '3/3/2017 2:52:09 AM'),
(36, 'a', '3/3/2017 2:57:25 AM'),
(37, 'a', '3/3/2017 2:58:06 AM'),
(38, 'a', '3/3/2017 2:59:41 AM'),
(39, 'a', '3/3/2017 3:00:06 AM'),
(40, 'a', '3/3/2017 3:01:43 AM'),
(41, 'a', '3/3/2017 3:01:58 AM'),
(42, 'a', '3/3/2017 3:02:11 AM'),
(43, 'a', '3/3/2017 3:02:43 AM'),
(44, 'a', '3/3/2017 3:04:20 AM'),
(45, 'a', '3/3/2017 3:05:14 AM'),
(46, 'a', '3/3/2017 3:05:33 AM'),
(47, 'a', '3/3/2017 3:06:47 AM'),
(48, 'a', '3/3/2017 3:09:28 AM'),
(49, 'a', '3/3/2017 3:09:42 AM'),
(50, 'a', '3/3/2017 3:13:30 AM'),
(51, 'a', '3/3/2017 3:16:19 AM'),
(52, 'a', '3/3/2017 3:17:14 AM'),
(53, 'a', '3/3/2017 3:19:16 AM'),
(54, 'a', '3/3/2017 3:20:15 AM'),
(55, 'a', '3/3/2017 3:23:41 AM'),
(56, 'a', '3/3/2017 3:27:29 AM'),
(57, 'a', '3/3/2017 3:31:15 AM'),
(58, 'a', '3/3/2017 3:48:24 AM'),
(59, 'a', '3/3/2017 4:02:28 AM'),
(60, 'a', '3/3/2017 4:03:31 AM'),
(61, 'a', '3/3/2017 4:04:07 AM'),
(62, 'a', '3/3/2017 4:25:05 AM'),
(63, 'a', '3/3/2017 4:25:44 AM'),
(64, 'admin', '3/3/2017 4:27:46 AM'),
(65, 'admin', '3/3/2017 4:31:06 AM'),
(66, 'a', '3/3/2017 4:33:25 AM'),
(67, 'a', '3/3/2017 4:34:05 AM'),
(68, 'admin', '3/3/2017 4:35:42 AM'),
(69, 'a', '3/3/2017 4:37:01 AM'),
(70, 'admin', '3/3/2017 4:38:39 AM'),
(71, 'admin', '3/3/2017 4:40:02 AM'),
(72, 'admin', '3/3/2017 4:41:32 AM'),
(73, 'a', '3/3/2017 4:47:49 AM'),
(74, 'admin', '3/3/2017 8:24:58 AM'),
(75, 'admin', '3/5/2017 2:46:09 PM'),
(76, 'admin', '3/5/2017 2:47:02 PM'),
(77, 'admin', '3/5/2017 2:49:29 PM'),
(78, 'admin', '3/5/2017 2:52:15 PM'),
(79, 'admin', '3/5/2017 2:59:36 PM'),
(80, 'admin', '3/5/2017 11:18:04 PM'),
(81, 'admin', '3/5/2017 11:34:33 PM'),
(82, 'admin', '3/5/2017 11:36:58 PM'),
(83, 'admin', '3/5/2017 11:40:57 PM'),
(84, 'admin', '3/5/2017 11:43:30 PM'),
(85, 'admin', '3/6/2017 12:05:07 AM'),
(86, 'admin', '3/6/2017 12:05:19 AM'),
(87, 'admin', '3/6/2017 12:14:06 AM'),
(88, 'admin', '3/6/2017 12:14:47 AM'),
(89, 'admin', '3/6/2017 12:16:15 AM'),
(90, 'admin', '3/6/2017 12:17:03 AM'),
(91, 'admin', '3/6/2017 12:18:31 AM'),
(92, 'admin', '3/6/2017 12:25:45 AM'),
(93, 'admin', '3/6/2017 12:26:10 AM'),
(94, 'admin', '3/6/2017 12:27:42 AM'),
(95, 'admin', '3/6/2017 12:28:07 AM'),
(96, 'admin', '3/6/2017 12:45:45 AM'),
(97, 'admin', '3/6/2017 12:47:07 AM'),
(98, 'admin', '3/6/2017 12:57:38 AM'),
(99, 'admin', '3/6/2017 12:59:12 AM'),
(100, 'admin', '3/6/2017 1:11:28 AM'),
(101, 'admin', '3/6/2017 1:16:54 AM'),
(102, 'admin', '3/6/2017 1:20:34 AM'),
(103, 'admin', '3/6/2017 1:21:42 AM'),
(104, 'admin', '3/6/2017 1:22:02 AM'),
(105, 'admin', '3/6/2017 1:22:53 AM'),
(106, 'admin', '3/6/2017 1:25:38 AM'),
(107, 'admin', '3/6/2017 1:29:55 AM'),
(108, 'admin', '3/6/2017 1:30:57 AM'),
(109, 'admin', '3/6/2017 1:31:46 AM'),
(110, 'admin', '3/6/2017 1:32:17 AM'),
(111, 'admin', '3/6/2017 1:32:44 AM'),
(112, 'admin', '3/6/2017 1:33:09 AM'),
(113, 'admin', '3/6/2017 1:38:01 AM'),
(114, 'admin', '3/6/2017 1:38:37 AM'),
(115, 'admin', '3/6/2017 1:39:00 AM'),
(116, 'admin', '3/6/2017 1:39:27 AM');

-- --------------------------------------------------------

--
-- Table structure for table `userslogout`
--

CREATE TABLE `userslogout` (
  `UserLogNumber` int(20) NOT NULL,
  `TimeOut` varchar(60) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf16;

--
-- Dumping data for table `userslogout`
--

INSERT INTO `userslogout` (`UserLogNumber`, `TimeOut`) VALUES
(1, '2/15/2017 7:15:51 AM'),
(2, '2/15/2017 7:18:45 AM'),
(3, '2/15/2017 7:20:00 AM'),
(4, '2/15/2017 7:22:20 AM'),
(5, '2/15/2017 7:23:30 AM'),
(6, '2/15/2017 7:24:55 AM'),
(7, '2/15/2017 7:26:45 AM'),
(8, '2/15/2017 7:29:32 AM'),
(9, '2/15/2017 7:30:15 AM'),
(10, '2/15/2017 7:31:16 AM'),
(11, '2/15/2017 7:32:05 AM'),
(12, '2/15/2017 7:37:14 AM'),
(13, '2/15/2017 7:40:00 AM'),
(14, '2/15/2017 8:21:38 AM'),
(15, '2/15/2017 8:25:46 AM'),
(16, '2/15/2017 8:27:04 AM'),
(17, '2/15/2017 8:28:21 AM'),
(18, '2/15/2017 8:34:47 AM'),
(19, '2/15/2017 8:41:10 AM'),
(20, '2/15/2017 8:43:10 AM'),
(21, '2/15/2017 4:15:56 PM'),
(22, '2/15/2017 4:16:19 PM'),
(23, '2/15/2017 4:16:42 PM'),
(24, '2/15/2017 4:16:59 PM'),
(25, '2/15/2017 4:23:05 PM'),
(26, '2/15/2017 4:25:38 PM'),
(27, '2/17/2017 10:53:41 PM'),
(28, '2/28/2017 11:35:19 PM'),
(29, '2/28/2017 11:36:27 PM'),
(30, '2/28/2017 11:47:36 PM'),
(31, '3/1/2017 12:15:29 AM'),
(32, '3/1/2017 12:20:50 AM'),
(33, '3/1/2017 12:35:40 AM'),
(34, '3/1/2017 12:41:17 AM'),
(35, '3/1/2017 1:43:40 AM'),
(36, '3/1/2017 2:17:25 AM'),
(37, '3/1/2017 2:54:56 AM'),
(38, '3/1/2017 3:17:18 AM'),
(39, '3/1/2017 3:18:39 AM'),
(40, '3/1/2017 3:25:41 AM'),
(41, '3/3/2017 1:59:20 AM'),
(42, '3/3/2017 2:14:43 AM'),
(43, '3/3/2017 2:25:44 AM'),
(44, '3/3/2017 2:25:47 AM'),
(45, '3/3/2017 2:27:21 AM'),
(46, '3/3/2017 2:28:21 AM'),
(47, '3/3/2017 2:28:51 AM'),
(48, '3/3/2017 2:52:20 AM'),
(49, '3/3/2017 2:57:34 AM'),
(50, '3/3/2017 2:59:55 AM'),
(51, '3/3/2017 3:00:47 AM'),
(52, '3/3/2017 3:02:05 AM'),
(53, '3/3/2017 3:02:30 AM'),
(54, '3/3/2017 3:02:50 AM'),
(55, '3/3/2017 3:04:30 AM'),
(56, '3/3/2017 3:05:22 AM'),
(57, '3/3/2017 3:05:39 AM'),
(58, '3/3/2017 3:06:55 AM'),
(59, '3/3/2017 3:09:34 AM'),
(60, '3/3/2017 3:09:48 AM'),
(61, '3/3/2017 3:16:30 AM'),
(62, '3/3/2017 3:17:26 AM'),
(63, '3/3/2017 3:19:27 AM'),
(64, '3/3/2017 3:20:24 AM'),
(65, '3/3/2017 3:23:58 AM'),
(66, '3/3/2017 3:49:27 AM'),
(67, '3/3/2017 4:03:49 AM'),
(68, '3/3/2017 4:04:13 AM'),
(69, '3/3/2017 4:31:48 AM'),
(70, '3/3/2017 4:33:50 AM'),
(71, '3/3/2017 4:39:21 AM'),
(72, '3/3/2017 4:47:50 AM'),
(73, '3/3/2017 8:25:00 AM'),
(74, '3/5/2017 2:53:19 PM'),
(75, '3/5/2017 3:00:14 PM'),
(76, '3/5/2017 11:18:43 PM'),
(77, '3/5/2017 11:34:48 PM'),
(78, '3/5/2017 11:42:54 PM'),
(79, '3/5/2017 11:44:29 PM'),
(80, '3/6/2017 12:27:27 AM'),
(81, '3/6/2017 1:06:43 AM');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `tblcstmr`
--
ALTER TABLE `tblcstmr`
  ADD PRIMARY KEY (`ClientID`);

--
-- Indexes for table `tblemp`
--
ALTER TABLE `tblemp`
  ADD PRIMARY KEY (`EmpID`);

--
-- Indexes for table `tblservices`
--
ALTER TABLE `tblservices`
  ADD PRIMARY KEY (`ServiceID`);

--
-- Indexes for table `tbltrans`
--
ALTER TABLE `tbltrans`
  ADD PRIMARY KEY (`No`);

--
-- Indexes for table `tbltrans2`
--
ALTER TABLE `tbltrans2`
  ADD PRIMARY KEY (`No`);

--
-- Indexes for table `tbltranscancelled`
--
ALTER TABLE `tbltranscancelled`
  ADD PRIMARY KEY (`TransID`),
  ADD UNIQUE KEY `TransID` (`TransID`);

--
-- Indexes for table `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`Username`);

--
-- Indexes for table `userslogin`
--
ALTER TABLE `userslogin`
  ADD PRIMARY KEY (`UserLogNumber`);

--
-- Indexes for table `userslogout`
--
ALTER TABLE `userslogout`
  ADD PRIMARY KEY (`UserLogNumber`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `tblcstmr`
--
ALTER TABLE `tblcstmr`
  MODIFY `ClientID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=10017;
--
-- AUTO_INCREMENT for table `tblemp`
--
ALTER TABLE `tblemp`
  MODIFY `EmpID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=20016;
--
-- AUTO_INCREMENT for table `tblservices`
--
ALTER TABLE `tblservices`
  MODIFY `ServiceID` int(5) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=35;
--
-- AUTO_INCREMENT for table `tbltrans`
--
ALTER TABLE `tbltrans`
  MODIFY `No` int(4) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=15;
--
-- AUTO_INCREMENT for table `tbltrans2`
--
ALTER TABLE `tbltrans2`
  MODIFY `No` int(4) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;
--
-- AUTO_INCREMENT for table `tbltranscancelled`
--
ALTER TABLE `tbltranscancelled`
  MODIFY `TransID` int(100) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT for table `userslogin`
--
ALTER TABLE `userslogin`
  MODIFY `UserLogNumber` int(10) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=117;
--
-- AUTO_INCREMENT for table `userslogout`
--
ALTER TABLE `userslogout`
  MODIFY `UserLogNumber` int(20) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=82;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
