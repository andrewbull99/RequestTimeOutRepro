# RequestTimeOutRepro
The is a test solution to reproduce the Kestrel "BadHttpRequestException - Request timed out" Exception

To reproduce the issue:
  * publish the web application
  * set up a reverse proxy in IIS to host the web application
  * Add the path to a large file (I was using an 800 MB file) to the console app config file
  * Run the console app, it will try to upload the specified file to the web app
  * Check the log file for the exception
  * Alternatively, use curl: <pre> curl -F 'data=@PathToLargeFile' http\://localhost:5000/api/values/upload </pre>
