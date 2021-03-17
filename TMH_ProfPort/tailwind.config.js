module.exports = {
    plugins: [
        require('@tailwindcss/typography'),
        require('daisyui'),
        // ...
    ],
    theme: {
        extend: {
            colors: require('daisyui/colors'),
        },
    },
    purge: {
        content: ['yourfiles/**/*.html'],
        options: {
            safelist: [
                /data-theme$/,
            ]
        },
    },
    daisyui: {
        styled: true,
        themes: true,
        rtl: false,
    },
}