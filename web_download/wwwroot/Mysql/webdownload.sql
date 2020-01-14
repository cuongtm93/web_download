-- phpMyAdmin SQL Dump
-- version 4.9.2
-- https://www.phpmyadmin.net/
--
-- Máy chủ: 127.0.0.1
-- Thời gian đã tạo: Th1 14, 2020 lúc 03:46 AM
-- Phiên bản máy phục vụ: 10.4.11-MariaDB
-- Phiên bản PHP: 7.4.1

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Cơ sở dữ liệu: `webdownload`
--
CREATE DATABASE IF NOT EXISTS `webdownload` DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci;
USE `webdownload`;

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `tblaccount`
--

CREATE TABLE IF NOT EXISTS `tblaccount` (
  `ID` int(11) NOT NULL,
  `role` int(11) NOT NULL,
  `username` text NOT NULL,
  `password` text NOT NULL,
  `activated` int(11) NOT NULL,
  `deleted` int(11) NOT NULL,
  `mobile` text DEFAULT NULL,
  `Fullname` text NOT NULL,
  `date_of_birth` datetime NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Đang đổ dữ liệu cho bảng `tblaccount`
--

INSERT INTO `tblaccount` (`ID`, `role`, `username`, `password`, `activated`, `deleted`, `mobile`, `Fullname`, `date_of_birth`) VALUES
(1, 1, 'admin', '2813baaae9ffe4524ef7819124a0d38c81846880947abf0672d877c2f28106b2', 1, 0, '0353237140', 'Trần Mạnh Cường', '2020-01-22 00:00:00');

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `tblcategory`
--

CREATE TABLE IF NOT EXISTS `tblcategory` (
  `ID` int(11) NOT NULL,
  `name` text NOT NULL,
  `url` text NOT NULL,
  `order` int(11) NOT NULL,
  `icon` text DEFAULT NULL,
  `ParentID` int(11) DEFAULT NULL,
  `text` text DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Đang đổ dữ liệu cho bảng `tblcategory`
--

INSERT INTO `tblcategory` (`ID`, `name`, `url`, `order`, `icon`, `ParentID`, `text`) VALUES
(1, 'Linux', 'linux', 2, 'https://upload.wikimedia.org/wikipedia/commons/thumb/3/35/Tux.svg/270px-Tux.svg.png', NULL, NULL),
(2, 'Windows xp', 'win-xp', 1, 'http://icons.iconarchive.com/icons/tatice/operating-systems/128/Windows-icon.png', 3, NULL),
(3, 'Windows', 'windows', 1, 'http://icons.iconarchive.com/icons/martz90/circle/128/windows-8-icon.png', NULL, NULL),
(4, 'Văn phòng', 'vangphong', 3, 'http://icons.iconarchive.com/icons/tatice/operating-systems/128/Windows-icon.png', 3, NULL),
(5, 'Game', 'game', 4, 'https://upload.wikimedia.org/wikipedia/commons/thumb/3/35/Tux.svg/270px-Tux.svg.png', 3, NULL),
(6, 'Ubuntu', 'Ubuntu', 5, 'http://icons.iconarchive.com/icons/tatice/operating-systems/128/Ubuntu-icon.png', 1, NULL);

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `tblsoftware`
--

CREATE TABLE IF NOT EXISTS `tblsoftware` (
  `ID` int(11) NOT NULL,
  `DateAdd` datetime NOT NULL,
  `Name` text NOT NULL,
  `icon` text NOT NULL,
  `rating` float NOT NULL DEFAULT 0,
  `provider` text DEFAULT NULL,
  `version` text DEFAULT NULL,
  `lience` int(11) NOT NULL,
  `size` int(11) NOT NULL,
  `viewed` int(11) NOT NULL,
  `downloaded` int(11) NOT NULL,
  `operating_systems` text DEFAULT NULL,
  `text` text DEFAULT NULL,
  `main_download` text DEFAULT NULL,
  `related_downloadID` int(11) DEFAULT NULL,
  `tags` text DEFAULT NULL,
  `categoryID` int(11) NOT NULL,
  `Visible` int(11) NOT NULL,
  `short_url` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Đang đổ dữ liệu cho bảng `tblsoftware`
--

INSERT INTO `tblsoftware` (`ID`, `DateAdd`, `Name`, `icon`, `rating`, `provider`, `version`, `lience`, `size`, `viewed`, `downloaded`, `operating_systems`, `text`, `main_download`, `related_downloadID`, `tags`, `categoryID`, `Visible`, `short_url`) VALUES
(1, '2020-01-11 10:11:12', 'Microsoft Office 2016', '/images/office.png', 2, NULL, NULL, 1, 0, 50, 11, 'Windows 7 | 8.1  | 10', '<p><strong>Office 2016</strong> là phiên bản mới của Microsoft. Là bộ ứng dụng văn phòng với nhiều công cụ mạnh mẽ hơn Office 2010, 2007, 2003.</p><figure class=\"image\"><img src=\"https://caidatphanmem.net/wp-content/uploads/2018/11/microsoft-office-2016-120718-711x400.png\" alt=\"\" srcset=\"https://caidatphanmem.net/wp-content/uploads/2018/11/microsoft-office-2016-120718-711x400.png 711w, https://caidatphanmem.net/wp-content/uploads/2018/11/microsoft-office-2016-120718-768x432.png 768w, https://caidatphanmem.net/wp-content/uploads/2018/11/microsoft-office-2016-120718.png 1280w\" sizes=\"100vw\" width=\"711\"></figure><p>&nbsp;</p><p><strong>Office 2016</strong> mang lại một cách làm việc mới, hiệu quả với nhiều tính năng. Sau đây, mình sẽ hướng dẫn các bạn&nbsp;<i>Download Office 2016.</i></p><h3>Hướng Dẫn Cách Download Office 2016 Full Crack</h3><p>+)<strong> Link tải</strong>:</p><ul><li><a href=\"http://123link.pro/X6riz\"><strong>Office 2016 64bit</strong></a></li><li><a href=\"http://123link.pro/eoeHgNa\"><strong>Office 2016 32bit</strong></a></li></ul><p>+) <strong>key:&nbsp; &nbsp; NKGG6-WBPCC-HXWMY-6DQGJ-CPQVG</strong></p><h3>Hướng dẫn cách cài đặt Office 2016</h3><p>Tương tự như cài Office 2010 và Office 2007.</p><p>Bạn có thể tham khảo cách cài đặt <a href=\"https://caidatphanmem.net/tai-microsoft-office-2010-full-key-ban-quyen-mien-phi/\"><strong>Office 2010</strong></a> và <a href=\"https://caidatphanmem.net/tai-va-cai-dat-office-2007-crack-key-caidatphanmem-net/\"><strong>Office 2007.</strong></a></p><p><strong>Bước 1:</strong></p><p>Sau khi tải về, bạn tiến hành cài đặt trên máy tính( phụ thuộc vào máy tính + tốc độ truyền mạng).</p><p>Khi <strong>cài đặt</strong> hoàn tất =&gt; nhấn <strong>close .</strong></p>', 'http://123link.pro/X6riz55555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555\r\nhttp://123link.pro/X6riz55555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555\r\n', NULL, NULL, 4, 1, 'microsoft-office'),
(2, '2020-01-13 13:37:45', 'Microsoft Office 2019', '/assets/images/eco-product-img-1.png', 0, 'Microsoft', '71', 0, 0, 48, 6, 'Windows xp', NULL, NULL, NULL, NULL, 4, 1, 'windows');

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `tbltop`
--

CREATE TABLE IF NOT EXISTS `tbltop` (
  `ID` int(11) NOT NULL,
  `Week` text DEFAULT NULL,
  `Top` text DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `__efmigrationshistory`
--

CREATE TABLE IF NOT EXISTS `__efmigrationshistory` (
  `MigrationId` varchar(150) CHARACTER SET utf8 NOT NULL,
  `ProductVersion` varchar(32) CHARACTER SET utf8 NOT NULL,
  PRIMARY KEY (`MigrationId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Đang đổ dữ liệu cho bảng `__efmigrationshistory`
--

INSERT INTO `__efmigrationshistory` (`MigrationId`, `ProductVersion`) VALUES
('20200114023441_Initial', '2.1.14-servicing-32113'),
('20200114024127_NotAllowNull', '2.1.14-servicing-32113');
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
