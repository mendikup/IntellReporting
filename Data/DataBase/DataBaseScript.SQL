CREATE TABLE IntelReports (
    id INT PRIMARY KEY AUTO_INCREMENT,
    reporter_id INT,
    target_id INT,
    content TEXT,
    time_of_report DATETIME DEFAULT NOW(),
    FOREIGN KEY (reporter_id) REFERENCES people(id),
    FOREIGN KEY (target_id) REFERENCES people(id)
);

    
CREATE TABLE alerts
        (id INT PRIMARY KEY AUTO_INCREMENT,
            target_id INT,
            raesone VARCHAR(50),
            time_of_creation DATETIME DEFAULT CURRENT_TIMESTAMP,
            FOREIGN KEY (target_id) REFERENCES people(id)
        );

    
