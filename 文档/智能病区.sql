/*
Navicat MySQL Data Transfer

Source Server         : localhost_3306
Source Server Version : 50724
Source Host           : localhost:3306
Source Database       : test

Target Server Type    : MYSQL
Target Server Version : 50724
File Encoding         : 65001

Date: 2020-05-22 08:48:32
*/

SET FOREIGN_KEY_CHECKS=0;

-- ----------------------------
-- Table structure for checkin_log
-- ----------------------------
DROP TABLE IF EXISTS `checkin_log`;
CREATE TABLE `checkin_log` (
  `sId` varchar(255) NOT NULL,
  `nType` tinyint(1) DEFAULT '0' COMMENT '0:病人 1:陪护 2:访客',
  `dtCheckIn` datetime DEFAULT NULL,
  `dtCheckOut` datetime DEFAULT NULL,
  `sPatientId` varchar(255) DEFAULT NULL,
  KEY `index_nType` (`nType`) USING BTREE,
  KEY `index_dtCheckIn` (`dtCheckIn`) USING BTREE
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for config
-- ----------------------------
DROP TABLE IF EXISTS `config`;
CREATE TABLE `config` (
  `nMaxAccompanyCount` int(4) DEFAULT NULL COMMENT '最大陪同人员',
  `nMaxVisitorCount` int(4) DEFAULT NULL COMMENT '最大访客'
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for pass_log
-- ----------------------------
DROP TABLE IF EXISTS `pass_log`;
CREATE TABLE `pass_log` (
  `sId` varchar(255) NOT NULL,
  `nType` tinyint(1) DEFAULT '0' COMMENT '0:病人 1:陪护 2:访客',
  `dtPass` datetime DEFAULT NULL,
  `sPatientId` varchar(255) DEFAULT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for people
-- ----------------------------
DROP TABLE IF EXISTS `people`;
CREATE TABLE `people` (
  `sId` varchar(255) NOT NULL COMMENT '身份证',
  `nType` tinyint(1) DEFAULT '0' COMMENT '0:病人 1:陪护 2:访客',
  `dtCheckIn` datetime DEFAULT NULL COMMENT '登记时间',
  `sPatientId` varchar(255) DEFAULT NULL COMMENT '关联的病人，本身是病人(nType==0)时则为空',
  PRIMARY KEY (`sId`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COMMENT='已登记的人员';

-- ----------------------------
-- Table structure for people_base_info
-- ----------------------------
DROP TABLE IF EXISTS `people_base_info`;
CREATE TABLE `people_base_info` (
  `sId` varchar(255) NOT NULL COMMENT '身份证',
  `sName` varchar(255) DEFAULT NULL COMMENT '姓名',
  `sPhone` varchar(255) DEFAULT NULL,
  `sAddress` varchar(255) DEFAULT NULL COMMENT '地址',
  PRIMARY KEY (`sId`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COMMENT='人员基础信息';
