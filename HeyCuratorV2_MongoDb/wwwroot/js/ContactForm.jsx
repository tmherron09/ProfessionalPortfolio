

class ContactForm extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            name: '',
            email: '',
            text: ''
        };
        this.handleNameChange = this.handleNameChange.bind(this);
        this.handleEmailChange = this.handleEmailChange.bind(this);
        this.handleTextChange = this.handleTextChange.bind(this);
        this.handleSubmit = this.handleSubmit.bind(this);
    }

    handleNameChange(e) {
        this.setState({ name: e.target.value });
    }
    handleEmailChange(e) {
        this.setState({ email: e.target.value });
    }
    handleTextChange(e) {
        this.setState({ text: e.target.value });
    }

    handleSubmit(e) {
        e.preventDefault();
        const name = this.state.name.trim();
        const email = this.state.email.trim();
        const text = this.state.text.trim();
        if (!this.state.text) {
            return;
        }


        const data = new FormData();
        data.append('Name', name);
        data.append('Email', email);
        data.append('Text', text);
        data.append('SubmitTime', null);


        const xhr = new XMLHttpRequest();
        xhr.open('post', '/contact/submitcontactform', true);
        xhr.send(data);

        this.setState({ name: '', email: '', text: '' });
    }

    render() {
        return (

            <form className="bg-gray-100 shadow-sm rounded-md p-8" onSubmit={this.handleSubmit}>
                <h1 className="text-green-500 text-3xl font-bold mb-3">Inquiries/Comments</h1>
                <div className="mb-6">
                    <label htmlFor="name" className="mb-3 block text-gray-700">Name:</label>
                    <input
                        type="text"
                        id="name"
                        value={this.state.name}
                        onChange={this.handleNameChange}
                        className="bg-white rounded-md border border-gray-200 p-3 focus:outline-none w-full"
                        placeholder="Enter your name..."
                    />
                </div>

                <div className="mb-6">
                    <label htmlFor="email" className="mb-3 block text-gray-700">Email address:</label>
                    <input
                        type="text"
                        id="email"
                        value={this.state.email}
                        onChange= {this.handleEmailChange}
                        className="bg-white rounded-md border border-gray-200 p-3 focus:outline-none w-full"
                        placeholder="Email address..."
                    />
                </div>
                <div className="mb-8">
                    <label htmlFor="message" className="mb-3 block text-gray-700">Inquiries/Comments:</label>
                    <textarea
                        id="message"
                        className="overflow-y-auto border rounded-md shadow-sm w-full p-3"
                        value={this.state.text}
                        onChange={this.handleTextChange}
                    />
                </div>
                <button
                    type="submit"
                    className="py-3 px-12 bg-green-500 hover:bg-green-700 mr-5 rounded-md text-white text-lg focus:outline-none w-full"
                >Submit Inquiry</button>
                
            </form>

        );
    }
}

ReactDOM.render(<ContactForm />, document.getElementById('contactForm'));