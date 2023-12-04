import styled, { css } from 'styled-components';

const ButtonStyled = styled.button`
  cursor: pointer;

  ${props =>
    props.variation === 'primary' &&
    css`
      background-color: var(--primary-900);
      color: var(--white);
      font-weight: 600;
      padding: 0.5rem 2rem;
      border-radius: var(--border-radius-2);
      border: none;
    `}

  ${props =>
    props.variation === 'secondary' &&
    css`
      color: var(--grey-200);
      background-color: var(--grey-900);
      font-weight: 600;
      padding: 0.5rem 2rem;
      border-radius: var(--border-radius-2);
      border: none;
    `}
    
  ${props =>
    props.variation === 'danger' &&
    css`
      color: var(--red-light);
      background-color: var(--red-dark);
      font-weight: 600;
      padding: 0.5rem 2rem;
      border-radius: var(--border-radius-2);

      &:hover {
        background-color: var(--red-light);
        color: var(--red-dark);
      }
    `}
    

  ${props =>
    props.disabled &&
    css`
      background-color: var(--grey-600);
      cursor: not-allowed;
    `}
`;

export const Button = ({
  children,
  onClick,
  className,
  type,
  variation,
  disabled,
}) => {
  return (
    <ButtonStyled
      onClick={onClick}
      className={className}
      type={type || 'button'}
      variation={variation}
      disabled={disabled}
    >
      {children}
    </ButtonStyled>
  );
};

ButtonStyled.defaultProps = {
  variation: 'secondary',
  disabled: false,
};
