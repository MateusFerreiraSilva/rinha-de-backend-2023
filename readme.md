# Running

```zsh
docker compose up -d
```

# Stress Test

To run stress tests, it is necessary that [Gatling](https://gatling.io/open-source/) to be configured on your machine and that the run-test.sh file is pointing to the location where Gatling is installed.

```zsh
cd stress-test
sudo ./run-test-sh
```