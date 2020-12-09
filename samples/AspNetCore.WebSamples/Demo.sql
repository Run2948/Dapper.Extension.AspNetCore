/*
 Navicat Premium Data Transfer

 Source Server         : localhost
 Source Server Type    : MySQL
 Source Server Version : 50724
 Source Host           : localhost:3306
 Source Schema         : Demo

 Target Server Type    : MySQL
 Target Server Version : 50724
 File Encoding         : 65001

 Date: 09/12/2020 23:40:43
*/

SET NAMES utf8mb4;
SET FOREIGN_KEY_CHECKS = 0;

-- ----------------------------
-- Table structure for WeatherForecast
-- ----------------------------
DROP TABLE IF EXISTS `WeatherForecast`;
CREATE TABLE `WeatherForecast`  (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Date` datetime(0) NOT NULL,
  `TemperatureC` int(11) NOT NULL,
  `Summary` varchar(55) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  PRIMARY KEY (`Id`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 6 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of WeatherForecast
-- ----------------------------
INSERT INTO `WeatherForecast` VALUES (1, '2020-12-10 23:32:11', 6, 'Bracing');
INSERT INTO `WeatherForecast` VALUES (2, '2020-12-11 23:32:11', -10, 'Warm');
INSERT INTO `WeatherForecast` VALUES (3, '2020-12-12 23:32:11', -3, 'Hot');
INSERT INTO `WeatherForecast` VALUES (4, '2020-12-13 23:32:11', 11, 'Sweltering');
INSERT INTO `WeatherForecast` VALUES (5, '2020-12-14 23:32:11', 49, 'Hot');

SET FOREIGN_KEY_CHECKS = 1;
