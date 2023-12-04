import { Input } from './Input';

export const Select = ({ options, ...props }) => {
  return (
    <Input
      as='select'
      {...props}
      {...props.register(props.label, {
        required: 'This field is required',
      })}
      disabled={props.disabled}
    >
      {options.map(option => (
        <option value={option.value} key={option.value}>
          {option.label}
        </option>
      ))}
    </Input>
  );
};
