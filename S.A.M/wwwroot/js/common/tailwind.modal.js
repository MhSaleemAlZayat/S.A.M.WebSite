class Modal {
    constructor({ title = "", content = "", status = "info", size = "md", buttons = [] }) {
        this.title = title;
        this.content = content;
        this.status = status;
        this.size = size;
        this.buttons = buttons;
        this.modalElement = null;
        this.focusableEls = [];
        this.firstFocusEl = null;
        this.lastFocusEl = null;
        this.handleKeydown = this.#handleKeydown.bind(this);
    }

    #getSizeClass() {
        return {
            sm: "max-w-sm",
            md: "max-w-md",
            lg: "max-w-xl",
            xl: "max-w-2xl"
        }[this.size] || "max-w-md";
    }

    #getStatusIcon() {
        const icons = {
            success: '<i class="fa-solid fa-circle-check text-green-600 text-xl"></i>'/*`<svg class="w-6 h-6 text-green-600" fill="none" stroke="currentColor" stroke-width="2" viewBox="0 0 24 24"><path stroke-linecap="round" stroke-linejoin="round" d="M5 13l4 4L19 7" /></svg>`*/,
            danger: '<i class="fa-solid fa-circle-exclamation text-red-600 text-xl"></i>'/*`<svg class="w-6 h-6 text-red-600" fill="none" stroke="currentColor" stroke-width="2" viewBox="0 0 24 24"><path stroke-linecap="round" stroke-linejoin="round" d="M6 18L18 6M6 6l12 12" /></svg>`*/,
            warning: '<i class="fa-solid fa-triangle-exclamation text-yellow-600 text-xl"></i>'/*`<svg class="w-6 h-6 text-yellow-600" fill="none" stroke="currentColor" stroke-width="2" viewBox="0 0 24 24"><path stroke-linecap="round" stroke-linejoin="round" d="M12 9v2m0 4h.01M4.93 4.93l14.14 14.14M4.93 19.07l14.14-14.14" /></svg>`*/,
            info:  '<i class="fa-solid fa-circle-info text-blue-600 text-xl"></i>'/*`<svg class="w-6 h-6 text-blue-600" fill="none" stroke="currentColor" stroke-width="2" viewBox="0 0 24 24"><path stroke-linecap="round" stroke-linejoin="round" d="M13 16h-1v-4h-1m1-4h.01M12 2a10 10 0 100 20 10 10 0 000-20z" /></svg>`*/
        };
        return icons[this.status] || icons.info;
    }

    #trapFocus(e) {
        if (e.key !== 'Tab') return;

        if (e.shiftKey) {
            if (document.activeElement === this.firstFocusEl) {
                e.preventDefault();
                this.lastFocusEl.focus();
            }
        } else {
            if (document.activeElement === this.lastFocusEl) {
                e.preventDefault();
                this.firstFocusEl.focus();
            }
        }
    }

    #handleKeydown(e) {
        if (e.key === "Escape") this.close("esc");
        this.#trapFocus(e);
    }

    show() {
        document.body.classList.add("modal-open");

        this.modalElement = document.createElement("div");
        this.modalElement.className = "fixed inset-0 z-50 flex items-center justify-center bg-black bg-opacity-50";

        const modalBox = document.createElement("div");
        modalBox.className = `bg-white p-6 rounded-xl shadow-xl w-full ${this.#getSizeClass()} relative modal-enter`;
        modalBox.setAttribute("role", "dialog");
        modalBox.setAttribute("aria-modal", "true");

        modalBox.innerHTML = `
          <button class="absolute top-2 right-2 text-gray-400 hover:text-gray-700" id="closeBtn" aria-label="Close">✕</button>
          <div class="flex items-center gap-2 mb-4 mt-4">${this.#getStatusIcon()}<h2 class="text-xl font-semibold">${this.title}</h2></div>
          <div class="modal-content mb-4"></div>
          <div class="modal-buttons flex justify-end gap-2"></div>
        `;

        const contentContainer = modalBox.querySelector(".modal-content");
        if (typeof this.content === "string") {
            contentContainer.innerHTML = this.content;
        } else {
            contentContainer.appendChild(this.content);
        }

        const buttonsContainer = modalBox.querySelector(".modal-buttons");
        this.buttons.forEach(({ label, className = "", onClick }) => {
            const btn = document.createElement("button");
            btn.textContent = label;
            btn.className = `px-4 py-2 rounded ${className}`;
            btn.onclick = () => {
                if (typeof onClick === "function") onClick(label);
                this.close(label);
            };
            buttonsContainer.appendChild(btn);
        });

        this.modalElement.appendChild(modalBox);
        document.body.appendChild(this.modalElement);
        setTimeout(() => modalBox.classList.add("modal-enter-active"), 10);

        // Focus trap setup
        this.focusableEls = modalBox.querySelectorAll('button, input, select, textarea, a[href], [tabindex]:not([tabindex="-1"])');
        if (this.focusableEls.length > 0) {
            this.firstFocusEl = this.focusableEls[0];
            this.lastFocusEl = this.focusableEls[this.focusableEls.length - 1];
            this.firstFocusEl.focus();
        }

        document.addEventListener("keydown", this.handleKeydown);
        this.modalElement.querySelector("#closeBtn").onclick = () => this.close("close");
    }

    close(actionType) {
        const modalBox = this.modalElement.querySelector("div");
        modalBox.classList.remove("modal-enter-active");
        modalBox.classList.add("modal-leave", "modal-leave-active");

        setTimeout(() => {
            document.body.removeChild(this.modalElement);
            document.body.classList.remove("modal-open");
            document.removeEventListener("keydown", this.handleKeydown);
            console.log("Modal closed with action:", actionType);
        }, 200);
    }
}

//class Modal {
//    constructor({ title = "", content = "", status = "info", buttons = [] }) {
//        this.title = title;
//        this.content = content; // Can be a string or HTMLElement
//        this.status = status;
//        this.buttons = buttons; // Array of { label, class, onClick }
//        this.modalElement = null;
//    }

//    #getStatusIcon() {
//        const icons = {
//            success: `<svg class="w-6 h-6 text-green-600" fill="none" stroke="currentColor" stroke-width="2" viewBox="0 0 24 24"><path stroke-linecap="round" stroke-linejoin="round" d="M5 13l4 4L19 7" /></svg>`,
//            danger: `<svg class="w-6 h-6 text-red-600" fill="none" stroke="currentColor" stroke-width="2" viewBox="0 0 24 24"><path stroke-linecap="round" stroke-linejoin="round" d="M6 18L18 6M6 6l12 12" /></svg>`,
//            warning: `<svg class="w-6 h-6 text-yellow-600" fill="none" stroke="currentColor" stroke-width="2" viewBox="0 0 24 24"><path stroke-linecap="round" stroke-linejoin="round" d="M12 9v2m0 4h.01M4.93 4.93l14.14 14.14M4.93 19.07l14.14-14.14" /></svg>`,
//            info: `<svg class="w-6 h-6 text-blue-600" fill="none" stroke="currentColor" stroke-width="2" viewBox="0 0 24 24"><path stroke-linecap="round" stroke-linejoin="round" d="M13 16h-1v-4h-1m1-4h.01M12 2a10 10 0 100 20 10 10 0 000-20z" /></svg>`
//        };
//        return icons[this.status] || icons.info;
//    }

//    show() {
//        this.modalElement = document.createElement("div");
//        this.modalElement.className = "fixed inset-0 z-50 flex items-center justify-center bg-black bg-opacity-50";

//        const modalBox = document.createElement("div");
//        modalBox.className = "bg-white p-6 rounded-xl shadow-xl w-full max-w-md relative modal-enter";

//        // Icon + Title
//        modalBox.innerHTML = `
//          <button class="absolute top-2 right-2 text-gray-400 hover:text-gray-700" id="closeBtn">✕</button>
//          <div class="flex items-center gap-2 mb-4">${this.#getStatusIcon()}<h2 class="text-xl font-semibold">${this.title}</h2></div>
//          <div class="modal-content mb-4"></div>
//          <div class="modal-buttons flex justify-end gap-2"></div>
//        `;

//        // Insert content
//        const contentContainer = modalBox.querySelector(".modal-content");
//        if (typeof this.content === "string") {
//            contentContainer.innerHTML = this.content;
//        } else if (this.content instanceof HTMLElement) {
//            contentContainer.appendChild(this.content);
//        }

//        // Insert buttons
//        const buttonsContainer = modalBox.querySelector(".modal-buttons");
//        this.buttons.forEach(({ label, className = "", onClick }) => {
//            const btn = document.createElement("button");
//            btn.textContent = label;
//            btn.className = `px-4 py-2 rounded ${className}`;
//            btn.onclick = () => {
//                if (typeof onClick === "function") onClick();
//                this.close();
//            };
//            buttonsContainer.appendChild(btn);
//        });

//        // Append and animate
//        this.modalElement.appendChild(modalBox);
//        document.body.appendChild(this.modalElement);
//        setTimeout(() => modalBox.classList.add("modal-enter-active"), 10);

//        // Close button
//        this.modalElement.querySelector("#closeBtn").onclick = () => this.close();
//    }

//    close() {
//        const modalBox = this.modalElement.querySelector("div");
//        modalBox.classList.remove("modal-enter-active");
//        modalBox.classList.add("modal-leave", "modal-leave-active");

//        setTimeout(() => {
//            document.body.removeChild(this.modalElement);
//        }, 200);
//    }
//}