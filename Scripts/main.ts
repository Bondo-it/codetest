import DomUtil from "./Utilities/DomUtil";
import UrlUtil from "./Utilities/UrlUtil";
import HtmlLoader from "./Utilities/HtmlLoader";
import * as tingle from "tingle.js";
import MakeRequest from "./Utilities/MakeRequest";

export default class App {
  constructor() {}

  execute() {
    try {
      this.setListeners();
    } catch (error) {}
  }

  setListeners() {
    var usersRows = document.querySelectorAll(".user");
    [].slice
    .call(usersRows)
    .forEach((element: Element, index: number, array: HTMLElement[]) => {
        element.addEventListener(
          "click",
          () => {
            const domUtil = new DomUtil(element);
            const urlUtil = new UrlUtil();
            const userId = domUtil.getDataAttr("userid");
            const userUrl = `${urlUtil.baseUrl()}/api/modal/user?id=${userId}`;
            new HtmlLoader("#userModal").load(userUrl);
            new MakeRequest(userUrl)
              .send()
              .then(data => {
                const modal = new tingle.modal({
                  footer: true,
                  stickyFooter: false,
                  closeMethods: ["overlay", "button", "escape"],
                  closeLabel: "Close",
                  cssClass: ["custom-class-1", "custom-class-2"],
                  beforeClose: () => true
                });
                modal.setContent(data);
                modal.open();
              })
              .catch(err => {
                console.error("Augh, there was an error!", err.statusText);
              });
          },
          false
        );
      });
  }
}

document.onreadystatechange = () => {
  if (document.readyState == "interactive") {
    new App().execute();
  }
};