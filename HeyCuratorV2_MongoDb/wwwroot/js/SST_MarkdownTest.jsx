const ReactMarkdown = require('react-markdown');

const mdTest = `
# Live demo

Changes are automatically rendered as you type.

* Implements[GitHub Flavored Markdown](https://github.github.com/gfm/)
* Renders actual, "native" React DOM elements
* Allows you to escape or skip HTML (try toggling the checkboxes above)

## HTML block below

< blockquote >
    This blockquote will change based on the HTML settings above.
</blockquote >

## How about some code ?

\`\`\`js
var React = require('react');
var Markdown = require('react-markdown');

React.render(
  <Markdown source="# Your markdown here" />,
  document.getElementById('content')
);
\`\`\`

Pretty neat, eh ?`;

ReactDOM.render(<ReactMarkdown children={mdTest} />, document.getElementById('markdown-tag'));
