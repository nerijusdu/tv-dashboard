# tv-dashboard

Modular home dashboard to be displayed on TV or any other display.


## Setup on RaspberryPi

### Pre-requisites
- nginx

### Steps
- Build `TvDashboard` and `TvDashBoard.Backend` projects as self-contained apps
- Copy `TvDasboard.Backend` to `/home/pi/web/TvDashboard`
- Copy `wwwroot` folder contents from `TvDashboard` project to `/home/pi/web/TvDashboard/wwwroot`
- Copy `Infra/tv-dashboard` file to `/etc/nginx/sites-available/`
- Run `ln -s /etc/sites-available/tv-dashboard /etc/sites-enabled/tv-dashboard`
- Copy `Infra/tv-dashboard.service` file to `/etc/systemd/system/`
- Run `sudo systemctl daemon-reload`
- Run `sudo systemctl start tv-dashboard`
- Run `sudo systemctl enable tv-dashboard` to run it every time raspberrypi turns on
- Run `sudo service nginx restart`
- Dashboard should be available on `http://localhost:90` (or using raspberrypi's IP with port 90)
