var helpers = new function () {
    const QUILL_TOOL_BAR_OPTIONS = [
        ['bold', 'italic', 'underline'],
        [{ 'size': ['small', false, 'large', 'huge'] }],
        [{ 'list': 'ordered' }, { 'list': 'bullet' }, 'link'],
        [{ 'indent': '-1' }, { 'indent': '+1' }],
        [{ 'header': [1, 2, 3, 4, 5, 6, false] }],
        [{ 'color': [] }, { 'background': [] }],
        [{ 'font': [] }],
        [{ 'align': [] }],
        ['clean']
    ];

    this.getQuillBarOptions = function () {
        return QUILL_TOOL_BAR_OPTIONS;
    };

    this.convertFormToObject = function (formId) {
        var fields = $("#" + formId).find('[disabled]');
        fields.prop('disabled', false);
        var array = $("#" + formId).serializeArray();
        fields.prop('disabled', true);
        var data = {};
        $(array).each(function (index, obj) {
            data[obj.name] = obj.value;
        });
        return data;
    };

    this.blockUI = function () {
        var modal = new bootstrap.Modal(document.getElementById('blockAppliactionDialog'), {
            backdrop: 'static',
            keyboard: false
        });
        modal.show();
    };

    this.unblockUI = function () {
        $('#blockAppliactionDialog').modal('hide');
    };

    this.getErrorMessage = function (json) {
        let result = "";

        for (var k in json) {
            for (var x in json[k]) {
                if (result == "")
                    result += json[k][x];
                else
                    result += ";" + json[k][x];
            }
        }

        return result;
    }

    this.copyInputValueToClipboard = async function (inputId, button) {
        let input = document.getElementById(inputId);
        if (!input) {
            console.error("Failed to find input with id: ", inputId);
            return;
        }

        // Check if Clipboard API is available
        if (navigator.clipboard && typeof navigator.clipboard.writeText === 'function') {
            try {
                await navigator.clipboard.writeText(input.value);
                button.textContent = "Copiado!";
                setTimeout(() => {
                    button.textContent = "Copiar";
                }, 3000);
            } catch (err) {
                console.error("Failed to copy text using Clipboard API: ", err);
                helpers.fallbackCopyTextToClipboard(input.value, button);
            }
        } else {
            console.warn("Clipboard API not available. Using fallback.");
            helpers.fallbackCopyTextToClipboard(input.value, button);
        }
    }

    this.fallbackCopyTextToClipboard = function (text, button) {
        let textArea = document.createElement("textarea");
        textArea.value = text;
        document.body.appendChild(textArea);
        textArea.focus();
        textArea.select();

        try {
            let successful = document.execCommand('copy');
            let msg = successful ? 'successful' : 'unsuccessful';
            console.log('Fallback: Copying text command was ' + msg);
            if (successful) {
                button.textContent = "Copiado!";
                setTimeout(() => {
                    button.textContent = "Copiar";
                }, 3000);
            }
        } catch (err) {
            console.error('Fallback: Oops, unable to copy', err);
        }

        document.body.removeChild(textArea);
    }
}