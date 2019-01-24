import DomUtil from "./Utilities/DomUtil";
import UrlUtil from "./Utilities/UrlUtil";
import HtmlLoader from "./Utilities/HtmlLoader";

export default class App {
    constructor() {
    }

    execute() {
        try {
            this.setListeners()
        } catch (error) {
        }
    }

    setListeners() {
        var usersRows = document.querySelectorAll('.user');
        [].slice
            .call(usersRows)
            .forEach((element: Element, index: number, array: HTMLElement[]) => {
                element.addEventListener(
                    "click",
                    () => {
                        const domUtil = new DomUtil(element);
                        const urlUtil = new UrlUtil();
                        var userId = domUtil.getDataAttr('userid');
                        const userUrl = `${urlUtil.baseUrl()}/api/modal/user?id=${userId}`;
                        new HtmlLoader('#userModal').load(userUrl);
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
