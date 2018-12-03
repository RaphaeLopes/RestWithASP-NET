
CREATE TABLE `books` (
	`Id` varchar(127) NOT NULL,
	`author` longtext,
	`launchDate` datetime(6) NOT NULL,
	`price` decimal(65,2) NOT NULL,
	`title` longtext,
	PRIMARY KEY (`id`)
) ENGINE = InnoDB DEFAULT CHARSET=latin1;