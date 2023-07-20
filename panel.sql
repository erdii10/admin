# Host: localhost  (Version 5.5.62)
# Date: 2022-02-15 18:21:04
# Generator: MySQL-Front 6.1  (Build 1.26)


#
# Structure for table "contact"
#

DROP TABLE IF EXISTS `contact`;
CREATE TABLE `contact` (
  `Id` smallint(6) NOT NULL AUTO_INCREMENT,
  `harita` text COLLATE utf8_turkish_ci,
  `en` varchar(10) COLLATE utf8_turkish_ci DEFAULT NULL,
  `boy` varchar(10) COLLATE utf8_turkish_ci DEFAULT NULL,
  `adres` text COLLATE utf8_turkish_ci,
  `telefon` varchar(15) COLLATE utf8_turkish_ci DEFAULT NULL,
  `eposta` varchar(255) COLLATE utf8_turkish_ci DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8 COLLATE=utf8_turkish_ci;

#
# Data for table "contact"
#

INSERT INTO `contact` VALUES (1,'','100%','450','Adres','telefon','erdipolat@outlook.comm');

#
# Structure for table "contents"
#

DROP TABLE IF EXISTS `contents`;
CREATE TABLE `contents` (
  `Id` smallint(6) NOT NULL AUTO_INCREMENT,
  `title` varchar(50) COLLATE utf8_turkish_ci DEFAULT NULL,
  `keywords` varchar(255) COLLATE utf8_turkish_ci DEFAULT '',
  `description` varchar(100) COLLATE utf8_turkish_ci DEFAULT NULL,
  `katid` smallint(6) DEFAULT NULL,
  `baslik` varchar(255) COLLATE utf8_turkish_ci DEFAULT NULL,
  `baslikEN` varchar(255) COLLATE utf8_turkish_ci DEFAULT NULL,
  `icerik` text COLLATE utf8_turkish_ci,
  `resim` varchar(255) COLLATE utf8_turkish_ci DEFAULT NULL,
  `tarih` varchar(10) COLLATE utf8_turkish_ci DEFAULT NULL,
  `yazar` varchar(100) COLLATE utf8_turkish_ci DEFAULT NULL,
  `sira` smallint(6) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_turkish_ci ROW_FORMAT=COMPACT;

#
# Data for table "contents"
#


#
# Structure for table "contentsfile"
#

DROP TABLE IF EXISTS `contentsfile`;
CREATE TABLE `contentsfile` (
  `Id` smallint(6) NOT NULL AUTO_INCREMENT,
  `katid` smallint(6) DEFAULT NULL,
  `baslik` varchar(255) COLLATE utf8_turkish_ci DEFAULT NULL,
  `aciklama` text COLLATE utf8_turkish_ci,
  `yolu` varchar(100) COLLATE utf8_turkish_ci DEFAULT NULL,
  `turu` varchar(8) COLLATE utf8_turkish_ci DEFAULT NULL,
  `boyutu` varchar(7) COLLATE utf8_turkish_ci DEFAULT NULL,
  `sira` smallint(6) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_turkish_ci ROW_FORMAT=COMPACT;

#
# Data for table "contentsfile"
#


#
# Structure for table "contentsimage"
#

DROP TABLE IF EXISTS `contentsimage`;
CREATE TABLE `contentsimage` (
  `Id` smallint(6) NOT NULL AUTO_INCREMENT,
  `katid` smallint(6) DEFAULT NULL,
  `baslik` varchar(150) COLLATE utf8_turkish_ci DEFAULT NULL,
  `resim` varchar(150) COLLATE utf8_turkish_ci DEFAULT NULL,
  `sira` smallint(6) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_turkish_ci;

#
# Data for table "contentsimage"
#


#
# Structure for table "elist"
#

DROP TABLE IF EXISTS `elist`;
CREATE TABLE `elist` (
  `Id` smallint(6) NOT NULL AUTO_INCREMENT,
  `adsoyad` varchar(255) COLLATE utf8_turkish_ci DEFAULT NULL,
  `eposta` varchar(100) COLLATE utf8_turkish_ci DEFAULT NULL,
  `tarih` varchar(15) COLLATE utf8_turkish_ci DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_turkish_ci;

#
# Data for table "elist"
#


#
# Structure for table "gallery"
#

DROP TABLE IF EXISTS `gallery`;
CREATE TABLE `gallery` (
  `Id` smallint(6) NOT NULL AUTO_INCREMENT,
  `katid` smallint(6) DEFAULT NULL,
  `baslik` varchar(255) COLLATE utf8_turkish_ci DEFAULT NULL,
  `baslikEN` varchar(255) COLLATE utf8_turkish_ci DEFAULT NULL,
  `resim` varchar(255) COLLATE utf8_turkish_ci DEFAULT NULL,
  `sira` smallint(6) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_turkish_ci;

#
# Data for table "gallery"
#


#
# Structure for table "ik"
#

DROP TABLE IF EXISTS `ik`;
CREATE TABLE `ik` (
  `Id` smallint(6) NOT NULL AUTO_INCREMENT,
  `tc` varchar(11) COLLATE utf8_turkish_ci DEFAULT NULL,
  `adsoyad` varchar(255) COLLATE utf8_turkish_ci DEFAULT NULL,
  `cinsiyet` varchar(15) COLLATE utf8_turkish_ci DEFAULT NULL,
  `medenihal` varchar(5) COLLATE utf8_turkish_ci DEFAULT NULL,
  `cocuksay` smallint(3) DEFAULT NULL,
  `tel` varchar(50) COLLATE utf8_turkish_ci DEFAULT NULL,
  `eposta` varchar(100) COLLATE utf8_turkish_ci DEFAULT NULL,
  `adres` text COLLATE utf8_turkish_ci,
  `dogtar` varchar(15) COLLATE utf8_turkish_ci DEFAULT NULL,
  `meslek` varchar(100) COLLATE utf8_turkish_ci DEFAULT NULL,
  `baspoz` varchar(255) COLLATE utf8_turkish_ci DEFAULT NULL,
  `dosyayolu` varchar(100) COLLATE utf8_turkish_ci DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_turkish_ci ROW_FORMAT=COMPACT;

#
# Data for table "ik"
#


#
# Structure for table "loginlogs"
#

DROP TABLE IF EXISTS `loginlogs`;
CREATE TABLE `loginlogs` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `personelid` smallint(6) DEFAULT NULL,
  `girenkisi` varchar(255) COLLATE utf8_turkish_ci DEFAULT NULL,
  `bagzamani` varchar(20) COLLATE utf8_turkish_ci DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_turkish_ci;

#
# Data for table "loginlogs"
#


#
# Structure for table "logs"
#

DROP TABLE IF EXISTS `logs`;
CREATE TABLE `logs` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `personelid` smallint(4) DEFAULT NULL,
  `ipadres` varchar(16) COLLATE utf8_turkish_ci DEFAULT NULL,
  `bagzamani` varchar(50) COLLATE utf8_turkish_ci DEFAULT NULL,
  `durum` varchar(50) COLLATE utf8_turkish_ci DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_turkish_ci ROW_FORMAT=COMPACT;

#
# Data for table "logs"
#


#
# Structure for table "news"
#

DROP TABLE IF EXISTS `news`;
CREATE TABLE `news` (
  `Id` smallint(6) NOT NULL AUTO_INCREMENT,
  `title` varchar(50) COLLATE utf8_turkish_ci DEFAULT NULL,
  `keywords` varchar(255) COLLATE utf8_turkish_ci DEFAULT '',
  `description` varchar(100) COLLATE utf8_turkish_ci DEFAULT NULL,
  `katid` smallint(6) DEFAULT NULL,
  `baslik` varchar(255) COLLATE utf8_turkish_ci DEFAULT NULL,
  `baslikEN` varchar(255) COLLATE utf8_turkish_ci DEFAULT NULL,
  `icerik` text COLLATE utf8_turkish_ci,
  `resim` varchar(255) COLLATE utf8_turkish_ci DEFAULT NULL,
  `tarih` varchar(10) COLLATE utf8_turkish_ci DEFAULT NULL,
  `yazar` varchar(100) COLLATE utf8_turkish_ci DEFAULT NULL,
  `sira` smallint(6) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_turkish_ci ROW_FORMAT=COMPACT;

#
# Data for table "news"
#


#
# Structure for table "newsfile"
#

DROP TABLE IF EXISTS `newsfile`;
CREATE TABLE `newsfile` (
  `Id` smallint(6) NOT NULL AUTO_INCREMENT,
  `katid` smallint(6) DEFAULT NULL,
  `baslik` varchar(255) COLLATE utf8_turkish_ci DEFAULT NULL,
  `aciklama` text COLLATE utf8_turkish_ci,
  `yolu` varchar(100) COLLATE utf8_turkish_ci DEFAULT NULL,
  `turu` varchar(8) COLLATE utf8_turkish_ci DEFAULT NULL,
  `boyutu` varchar(7) COLLATE utf8_turkish_ci DEFAULT NULL,
  `sira` smallint(6) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_turkish_ci ROW_FORMAT=COMPACT;

#
# Data for table "newsfile"
#


#
# Structure for table "newsimage"
#

DROP TABLE IF EXISTS `newsimage`;
CREATE TABLE `newsimage` (
  `Id` smallint(6) NOT NULL AUTO_INCREMENT,
  `katid` smallint(6) DEFAULT NULL,
  `baslik` varchar(150) COLLATE utf8_turkish_ci DEFAULT NULL,
  `resim` varchar(150) COLLATE utf8_turkish_ci DEFAULT NULL,
  `sira` smallint(6) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_turkish_ci ROW_FORMAT=COMPACT;

#
# Data for table "newsimage"
#


#
# Structure for table "slider"
#

DROP TABLE IF EXISTS `slider`;
CREATE TABLE `slider` (
  `Id` smallint(6) NOT NULL AUTO_INCREMENT,
  `katid` smallint(6) DEFAULT NULL,
  `baslik` varchar(255) COLLATE utf8_turkish_ci DEFAULT NULL,
  `baslikEN` varchar(255) COLLATE utf8_turkish_ci DEFAULT NULL,
  `resim` varchar(255) COLLATE utf8_turkish_ci DEFAULT NULL,
  `sira` smallint(6) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_turkish_ci;

#
# Data for table "slider"
#


#
# Structure for table "sss"
#

DROP TABLE IF EXISTS `sss`;
CREATE TABLE `sss` (
  `Id` smallint(6) NOT NULL AUTO_INCREMENT,
  `soru` text COLLATE utf8_turkish_ci,
  `soruEN` text COLLATE utf8_turkish_ci,
  `cevap` text COLLATE utf8_turkish_ci,
  `sira` smallint(6) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_turkish_ci;

#
# Data for table "sss"
#


#
# Structure for table "survey"
#

DROP TABLE IF EXISTS `survey`;
CREATE TABLE `survey` (
  `Id` smallint(6) NOT NULL AUTO_INCREMENT,
  `katid` smallint(6) DEFAULT NULL,
  `baslik` varchar(255) COLLATE utf8_turkish_ci DEFAULT NULL,
  `baslikEN` varchar(255) COLLATE utf8_turkish_ci DEFAULT NULL,
  `sayac` smallint(6) DEFAULT '0',
  `sira` smallint(6) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_turkish_ci;

#
# Data for table "survey"
#


#
# Structure for table "timer"
#

DROP TABLE IF EXISTS `timer`;
CREATE TABLE `timer` (
  `Id` smallint(6) NOT NULL AUTO_INCREMENT,
  `katid` smallint(6) DEFAULT NULL,
  `baslik` varchar(255) COLLATE utf8_turkish_ci DEFAULT NULL,
  `baslikEN` varchar(255) COLLATE utf8_turkish_ci DEFAULT NULL,
  `resim` varchar(255) COLLATE utf8_turkish_ci DEFAULT NULL,
  `url` text COLLATE utf8_turkish_ci,
  `bastarih` varchar(255) COLLATE utf8_turkish_ci DEFAULT NULL,
  `bittarih` varchar(255) COLLATE utf8_turkish_ci DEFAULT NULL,
  `sira` smallint(6) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_turkish_ci;

#
# Data for table "timer"
#


#
# Structure for table "users"
#

DROP TABLE IF EXISTS `users`;
CREATE TABLE `users` (
  `Id` smallint(6) NOT NULL AUTO_INCREMENT,
  `adsoyad` varchar(100) COLLATE utf8_turkish_ci DEFAULT NULL,
  `firma` varchar(150) COLLATE utf8_turkish_ci DEFAULT NULL,
  `kadi` varchar(50) COLLATE utf8_turkish_ci DEFAULT NULL,
  `sifre` varchar(255) COLLATE utf8_turkish_ci DEFAULT NULL,
  `eposta` varchar(50) COLLATE utf8_turkish_ci DEFAULT NULL,
  `resim` varchar(255) COLLATE utf8_turkish_ci DEFAULT NULL,
  `tarih` varchar(10) COLLATE utf8_turkish_ci DEFAULT NULL,
  `sira` smallint(6) DEFAULT NULL,
  `icerikler` varchar(1) COLLATE utf8_turkish_ci DEFAULT NULL,
  `haberler` varchar(1) COLLATE utf8_turkish_ci DEFAULT NULL,
  `sss` varchar(1) COLLATE utf8_turkish_ci DEFAULT NULL,
  `zaman` varchar(1) COLLATE utf8_turkish_ci DEFAULT NULL,
  `video` varchar(1) COLLATE utf8_turkish_ci DEFAULT NULL,
  `eliste` varchar(1) COLLATE utf8_turkish_ci DEFAULT NULL,
  `anket` varchar(1) COLLATE utf8_turkish_ci DEFAULT NULL,
  `galeri` varchar(1) COLLATE utf8_turkish_ci DEFAULT NULL,
  `ik` varchar(1) COLLATE utf8_turkish_ci DEFAULT NULL,
  `slider` varchar(1) COLLATE utf8_turkish_ci DEFAULT NULL,
  `kullanicilar` varchar(1) COLLATE utf8_turkish_ci DEFAULT NULL,
  `iletisim` varchar(1) COLLATE utf8_turkish_ci DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_turkish_ci;

#
# Data for table "users"
#


#
# Structure for table "video"
#

DROP TABLE IF EXISTS `video`;
CREATE TABLE `video` (
  `Id` smallint(6) NOT NULL AUTO_INCREMENT,
  `katid` smallint(6) DEFAULT NULL,
  `baslik` varchar(255) COLLATE utf8_turkish_ci DEFAULT NULL,
  `baslikEN` varchar(255) COLLATE utf8_turkish_ci DEFAULT NULL,
  `url` varchar(255) COLLATE utf8_turkish_ci DEFAULT NULL,
  `sira` smallint(6) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_turkish_ci;

#
# Data for table "video"
#

