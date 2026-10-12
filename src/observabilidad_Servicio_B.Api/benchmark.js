import http from "k6/http";
import { sleep } from "k6";

export const options = {
    vus: 50,
    duration: "2m",
};

export default function () {

    http.get("http://localhost:8080/api/orders");

    sleep(1);
}