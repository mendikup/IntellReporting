CREATE TABLE IntelReports
			(id int PRIMARY KEY AUTO_INCREMENT,
                FOREIGN KEY(reporter_id) REFERENCES people(id),
                FOREIGN KEY(teget_id) REFERENCES people(id),
                content TEXT,
                time_of_report DATETIME DEFAULT NOW()
            )
             
          
             