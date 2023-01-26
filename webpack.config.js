const path = require('path');
const MiniCssExtractPlugin = require("mini-css-extract-plugin");

module.exports = {
    entry: './Content/expose-components.js',
    output: {
        globalObject: 'this',
        filename: '[name].js',
        path: path.resolve(__dirname, 'wwwroot/dist')
    },
    mode: (1 == 0 ? 'production' : 'development'),
    optimization: {
        runtimeChunk: {
            name: 'runtime',
        },
        splitChunks: {
            cacheGroups: {
                commons: {
                    test: /[\\/]node_modules[\\/](react|react-dom)[\\/]/,
                    name: 'vendor',
                    chunks: 'all',
                },
            },
        },
    },
    plugins: [new MiniCssExtractPlugin()],
    module: {
        rules: [
            {
                test: /\.jsx$/,
                exclude: /node_modules/,
                use: {
                    loader: "babel-loader"
                }
            },
            {
                test: /\.css$/i,
                use: [MiniCssExtractPlugin.loader, "css-loader"],
            },
        ],
    }
};