export default class MakeRequest {
  method: string;
  url: string;
  constructor(url: string, method: string = "get") {
    this.method = method;
    this.url = url;
  }

  send(body: string = null) {
    return new Promise((resolve, reject) => {
      const xmlHttpRequest = new XMLHttpRequest();
      xmlHttpRequest.open(this.method, this.url);

      if (body != null) {
          console.log('passou aqui');
          xmlHttpRequest.setRequestHeader("Accept", "*/*");
          xmlHttpRequest.setRequestHeader("Content-Type", "application/json");
    }

      xmlHttpRequest.onload = () => {
        if (xmlHttpRequest.status >= 200 && xmlHttpRequest.status < 300) {
          resolve(xmlHttpRequest.response);
        } else {
          reject({
            status: xmlHttpRequest.status,
            statusText: xmlHttpRequest.statusText
          });
        }
      };
      xmlHttpRequest.onerror = () => {
        reject({
          status: xmlHttpRequest.status,
          statusText: xmlHttpRequest.statusText
        });
      };
      xmlHttpRequest.send(body);

    });
  }
}
