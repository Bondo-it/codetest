export default class DomUtil {
	element: Element;
	constructor(element: Element) {
		this.element = element;
	}

	getDataAttr(attr: string, defaultvalue: string = undefined): any {
		if (!this.element) return null;
		const value = this.element.getAttribute(`data-${attr}`);

		return value !== undefined ? value : defaultvalue;
	}

	setDataAttr(attr: string, value: string): any {
		if (!this.element) return null;
		return this.element.setAttribute(`data-${attr}`, value);
	}

	getAttr(attr: string, defaultvalue: string = undefined): any {
		if (!this.element) return null;
		const value = this.element.getAttribute(attr)

		return value !== undefined ? value : defaultvalue;
	}

	setAttr(attr: string, value: string): void {
		if (!this.element) return null;
		this.element.setAttribute(attr, value);
	}

	removeAttr(attr: string): void {
		if (!this.element) return null;
		this.element.removeAttribute(attr);
	}

	hasAttr(attr: string): boolean {
		if (!this.element) return null;
		return this.element.hasAttribute(attr);
	}

	shake(): void {
		this.appendClass("shake");
		setTimeout(() => {
			this.removeClass("shake");
			(this.element as HTMLInputElement).readOnly = false;
		}, 300);
	}

	removeClass(classname) {
		this.element.classList.remove(classname);
	}

	appendClass(classname) {
		this.element.classList.add(classname);
	}
}
