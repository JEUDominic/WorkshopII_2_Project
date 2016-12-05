-- phpMyAdmin SQL Dump
-- version 4.5.1
-- http://www.phpmyadmin.net
--
-- Host: 127.0.0.1
-- Generation Time: Dec 03, 2016 at 05:44 AM
-- Server version: 10.1.8-MariaDB
-- PHP Version: 5.6.14

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `information`
--

-- --------------------------------------------------------

--
-- Table structure for table `habit`
--

CREATE TABLE `habit` (
  `studentID` varchar(10) NOT NULL,
  `character` int(1) NOT NULL,
  `interest` varchar(255) NOT NULL,
  `bedtime` int(1) NOT NULL,
  `waketime` int(1) NOT NULL,
  `smoke` int(1) NOT NULL,
  `clean` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `habit`
--

INSERT INTO `habit` (`studentID`, `character`, `interest`, `bedtime`, `waketime`, `smoke`, `clean`) VALUES
('1430003005', 1, 'Sport,Game,Study,Music,Drive', 3, 2, 0, 2),
('1430003023', 2, 'Study,Read,Game,Movie', 3, 1, 0, 2),
('1430003042', 3, 'Sport,Read,Movie,Art', 3, 0, 0, 2),
('1430003099', 1, 'Study,Read,', 1, 1, 1, 0);

-- --------------------------------------------------------

--
-- Table structure for table `information`
--

CREATE TABLE `information` (
  `studentID` varchar(10) NOT NULL,
  `studentName` varchar(40) NOT NULL,
  `studentBirth` int(8) NOT NULL,
  `studentGender` int(1) NOT NULL,
  `state` int(1) NOT NULL DEFAULT '0'
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `information`
--

INSERT INTO `information` (`studentID`, `studentName`, `studentBirth`, `studentGender`, `state`) VALUES
('10', 'Test', 19970723, 1, 0),
('1430003005', 'Allen', 19960119, 1, 0),
('1430003023', 'JEU', 19970723, 0, 1),
('1430003042', 'Joyce', 19970512, 0, 1),
('1430003099', 'J', 19970723, 0, 0);

-- --------------------------------------------------------

--
-- Table structure for table `roomate`
--

CREATE TABLE `roomate` (
  `roomateA` varchar(10) NOT NULL,
  `roomateB` varchar(10) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `roomate`
--

INSERT INTO `roomate` (`roomateA`, `roomateB`) VALUES
('1430003042', '1430003023');

-- --------------------------------------------------------

--
-- Table structure for table `will`
--

CREATE TABLE `will` (
  `studentID` varchar(10) NOT NULL,
  `w_character` int(1) NOT NULL,
  `w_interest` varchar(255) NOT NULL,
  `w_bedtime` int(1) NOT NULL,
  `w_waketime` int(1) NOT NULL,
  `w_smoke` int(1) NOT NULL,
  `w_clean` int(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `will`
--

INSERT INTO `will` (`studentID`, `w_character`, `w_interest`, `w_bedtime`, `w_waketime`, `w_smoke`, `w_clean`) VALUES
('1430003005', 1, 'Sport', 3, 2, 0, 2),
('1430003023', 2, 'Read', 2, 1, 0, 1),
('1430003042', 3, 'Study', 2, 3, 0, 2),
('1430003099', 1, 'Study,Read,', 2, 1, 1, 1);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `habit`
--
ALTER TABLE `habit`
  ADD PRIMARY KEY (`studentID`);

--
-- Indexes for table `information`
--
ALTER TABLE `information`
  ADD PRIMARY KEY (`studentID`);

--
-- Indexes for table `roomate`
--
ALTER TABLE `roomate`
  ADD UNIQUE KEY `roomateA_3` (`roomateA`),
  ADD UNIQUE KEY `roomateB_2` (`roomateB`),
  ADD KEY `roomateA` (`roomateA`,`roomateB`),
  ADD KEY `roomateA_2` (`roomateA`),
  ADD KEY `roomateB` (`roomateB`);

--
-- Indexes for table `will`
--
ALTER TABLE `will`
  ADD PRIMARY KEY (`studentID`);

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
