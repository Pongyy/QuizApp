-- phpMyAdmin SQL Dump
-- version 4.8.4
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Jun 13, 2020 at 09:45 AM
-- Server version: 10.1.37-MariaDB
-- PHP Version: 5.6.40

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `quiz`
--

-- --------------------------------------------------------

--
-- Table structure for table `quiz`
--

CREATE TABLE `quiz` (
  `qno` int(11) NOT NULL,
  `question` text NOT NULL,
  `opt1` text NOT NULL,
  `opt2` text NOT NULL,
  `opt3` text NOT NULL,
  `opt4` text NOT NULL,
  `pts` text NOT NULL,
  `ans` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `quiz`
--

INSERT INTO `quiz` (`qno`, `question`, `opt1`, `opt2`, `opt3`, `opt4`, `pts`, `ans`) VALUES
(1, 'What is the power house of the cell called?', 'Cell Membrane', 'Mitochondria', 'Nucleus', 'Ribosomes', '1', 'Mitochondria'),
(2, 'What is the basic social unit of society?', 'Money', 'Work Force', 'Government Officials', 'Family', '1', 'Family'),
(3, 'Smallest country in the world', 'South Korea', 'New Zealand', 'Vatican City', 'Singapore', '1', 'Vatican CIty'),
(4, 'What is the most abundant gas in Earth atmosphere?', 'Nitrogen', 'Helium', 'Oxygen', 'Carbon Dioxide', '1', 'Nitrogen'),
(5, 'What was the old name of the country Thailand', 'Krung Thep', 'Mai Chai', 'Khob Khun', 'Siam', '1', 'Siam'),
(6, 'Taj Mahal is located at?', 'India', 'Cambodia', 'Philippines', 'Thailand', '5', 'India'),
(7, 'Absolute Zero is equivalent to ___ degrees celcius?', '-273.15', '-285.30', '-220.50', '-250.00', '5', '-273.15'),
(8, 'Golds chemical symbol in Periodic Table', 'NA', 'SI', 'AG', 'AU', '5', 'AU'),
(9, 'Capital of the Philippines?', 'Manila', 'Baguio', 'Bulacan', 'Valenzuela', '5', 'Manila'),
(10, 'Old Philippine alphabet is called', 'Baybayin', 'ABAKADA', 'Alibata', 'Diptongo', '5', 'Baybayin');

-- --------------------------------------------------------

--
-- Table structure for table `scoresheet`
--

CREATE TABLE `scoresheet` (
  `fullname` text NOT NULL,
  `date` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `score` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `users`
--

CREATE TABLE `users` (
  `idnum` int(11) NOT NULL,
  `fullname` text NOT NULL,
  `username` varchar(20) NOT NULL,
  `password` varchar(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `users`
--

INSERT INTO `users` (`idnum`, `fullname`, `username`, `password`) VALUES
(1, 'Steven G. Rogers', 'captain', 'america'),
(2, 'Natasha Romanoff', 'black', 'widow'),
(3, 'John Paul Arcilla', 'pong', '123'),
(4, 'Von Jovy Slavador', 'von', 'jovi14');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `quiz`
--
ALTER TABLE `quiz`
  ADD PRIMARY KEY (`qno`);

--
-- Indexes for table `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`idnum`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `quiz`
--
ALTER TABLE `quiz`
  MODIFY `qno` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- AUTO_INCREMENT for table `users`
--
ALTER TABLE `users`
  MODIFY `idnum` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
