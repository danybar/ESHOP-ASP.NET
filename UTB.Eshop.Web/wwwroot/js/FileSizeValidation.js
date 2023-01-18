$.validator.addMethod('filesize',
    function (value, element, params) {
        var size = params[1];
        var fileSize = 0;
        if (element && element.files && element.files.length > 0) {
            fileSize = element.files[0].size;
        }

        if (!value || fileSize <= size) {
            return true;
        }

        return false;
    });


$.validator.unobtrusive.adapters.add('filesize', ['size'],
    function (options) {
        var element = $(options.form).find('#fileupload')[0];

        options.rules['filesize'] = [element, options.params['size']];
        options.messages['filesize'] = options.message;
    });