# Malshinon — Community Intel Reporting System

This is a simulation system designed to collect and analyze civilian-generated intelligence reports.

## Project Overview

The application allows users to log in using their full name or a secret code and submit free-text reports about other individuals in the community. The system stores all data in a MySQL database and tracks basic metrics, such as how many reports each person submitted or received.

## Implemented Features

- Person identification by name or secret code. If a person doesn't exist, a new entry is created and assigned a unique code.
- Report submission flow: users submit free-text intel, and the system automatically identifies or creates the relevant target.
- Basic status tracking: the number of reports submitted or received by each person is counted. Status is updated based on these metrics.
- Input validation to ensure correct formatting.
- MySQL database integration with proper connection handling.
- Terminal-based menu interface that guides the user through each step.

## Technologies

- C# (.NET 9)
- MySQL
- Git

## Notes

This version includes the core reporting and identity flow. Features like CSV import, alert generation, and analytics dashboards have not been implemented yet.
