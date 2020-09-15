import DomUtil from "../Utilities/DomUtil";
import CustomElement from "../Utilities/CustomElement.decorator";
import * as tingle from "tingle.js";
import UrlUtil from "../Utilities/UrlUtil";
import HtmlLoader from "../Utilities/HtmlLoader";
import MakeRequest from "../Utilities/MakeRequest";

@CustomElement({
    selector: 'user-modal',
    template: `<div></div>`,
    style: ``,
    useShadow: true,
})
export class UserModel extends HTMLElement {
    private userId: string;
    private domUtil: DomUtil;

    constructor() {
        super();
    }

    connectedCallback(): void {
        this.domUtil = new DomUtil(this);

        this.init();
    }

    init(): void {
        this.parseData();
        this.bindEvents();

        const urlUtil = new UrlUtil();
        const userUrl = `${urlUtil.baseUrl()}/api/modal/user?id=${this.userId}`;
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
                    beforeClose: () => { this.remove(); return true; },
                    onClose: () => { modal.destroy(); }
                });
                modal.setContent(data);
                modal.open();
            })
            .catch(err => {
                console.error("Augh, there was an error!", err.statusText);
            });
    }

    private parseData(): void {
        this.userId = this.getAttribute("user-id");
    }

    private bindEvents(): void {
    }
}
